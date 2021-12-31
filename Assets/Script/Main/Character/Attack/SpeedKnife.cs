using System.Collections;
using Script.Main.Enemy.Extension;
using Script.Main.Enemy.Interface;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using IAttack = Script.Main.Character.Interface.IAttack;

namespace Script.Main.Character.Attack{
	public class SpeedKnife : MonoBehaviour, IAttack{
		[SerializeField] private GameObject knifePre;
		[SerializeField] private float coldDown = 0.5f;
		[SerializeField] private float throwPower;


		private ColdDownTimer _timer;
		private Character _character;

		private void Start(){
			_character = GetComponent<Character>();
			_timer = new ColdDownTimer(coldDown);
		}

		public bool CanAttack(){
			var canInvoke = _timer.CanInvoke();
			return canInvoke;
		}

		private Coroutine _throwingTimer;

		public void Attack(Vector2 attackDirection, Vector2 targetPosition){
			_character.PlayAnimation("Attack", 1);
			if(_throwingTimer != null){
				StopCoroutine(_throwingTimer);
			}

			_throwingTimer = StartCoroutine(SecondThrowTimer(attackDirection));
			_timer.Reset();
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