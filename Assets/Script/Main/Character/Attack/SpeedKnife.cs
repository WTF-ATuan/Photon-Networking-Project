using System.Collections;
using System.Collections.Generic;
using Photon.Bolt;
using Script.Main.Enemy.Interface;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.Serialization;
using IAttack = Script.Main.Character.Interface.IAttack;

namespace Script.Main.Character.Attack{
	public class SpeedKnife : MonoBehaviour, IAttack{
		[SerializeField] private GameObject knifePre;

		[FormerlySerializedAs("throwSpeed")] [SerializeField]
		private float throwPower;


		private Character _character;

		private void Start(){
			_character = GetComponent<Character>();
		}

		public bool CanAttack(){
			return true;
		}

		private Coroutine _throwingTimer;

		public void Attack(Vector2 attackDirection, Vector2 targetPosition){
			_character.PlayAnimation("Attack", 1);
			if(_throwingTimer != null){
				StopCoroutine(_throwingTimer);
			}

			_throwingTimer = StartCoroutine(SecondThrowTimer(attackDirection));
		}

		private IEnumerator SecondThrowTimer(Vector2 direction){
			var entity = Instantiate(knifePre, transform.position + new Vector3(transform.right.x, 1, 0),
				Quaternion.identity);
			entity.transform.right = direction;
			ThrowKnife(entity, direction);
			yield return new WaitForSeconds(0.5f);
			var secondEntity = Instantiate(knifePre, transform.position + new Vector3(transform.right.x, 1, 0),
				Quaternion.identity);
			secondEntity.transform.right = direction;
			ThrowKnife(secondEntity, direction);
		}

		private void ThrowKnife(GameObject knife, Vector2 direction){
			knife.OnTriggerEnter2DAsObservable()
					.Subscribe(x => OnSkillTriggered(knife, x))
					.AddTo(knife);
			var knifeRig = knife.GetComponent<Rigidbody2D>();
			knifeRig.AddForce(direction * throwPower, ForceMode2D.Impulse);
			Destroy(knife, 5f);
		}

		private void OnSkillTriggered(GameObject skillObjectClone, Collider2D other){
			var modifyHp = other.GetComponent<IModifyHp>();
			modifyHp?.ModifyHp(-5);
			Destroy(skillObjectClone);
		}
	}
}