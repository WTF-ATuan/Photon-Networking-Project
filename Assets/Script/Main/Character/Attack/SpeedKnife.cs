using System.Collections;
using System.Collections.Generic;
using Photon.Bolt;
using Script.Main.Character.Interface;
using UnityEngine;
using UnityEngine.Serialization;

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

			_throwingTimer = StartCoroutine(SecondThrowTimer(attackDirection, targetPosition));
		}

		private IEnumerator SecondThrowTimer(Vector2 direction, Vector2 targetPosition){
			var entity = Instantiate(knifePre, transform.position + transform.right * 0.3f, Quaternion.identity);
			entity.transform.LookAt(targetPosition);
			var skillRig = entity.GetComponent<Rigidbody2D>();
			ThrowKnife(skillRig, direction);
			yield return new WaitForSeconds(0.5f);
			var secondEntity = Instantiate(knifePre, transform.position + transform.right * 0.3f, Quaternion.identity);
			secondEntity.transform.LookAt(targetPosition);
			var secondSkillRig = secondEntity.GetComponent<Rigidbody2D>();
			ThrowKnife(secondSkillRig, direction);
		}

		private void ThrowKnife(Rigidbody2D knifeRig, Vector2 direction){
			knifeRig.AddForce(direction * throwPower, ForceMode2D.Impulse);
		}

		private void OnSkillTriggered(BoltEntity skillObjectClone, Collision2D other){ }
	}
}