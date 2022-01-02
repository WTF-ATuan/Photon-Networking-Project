using Script.Main.Character.Interface;
using Script.Main.Enemy.Extension;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Script.Main.Character.Attack{
	public class Healing : MonoBehaviour, IAttack{
		[SerializeField] private GameObject healingObject;
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

		public void Attack(Vector2 attackDirection){
			_character.PlayAnimation("Attack", 1);
			Heal(attackDirection);
			_timer.Reset();
		}

		public void Heal(Vector3 direction){
			var entity = Instantiate(healingObject, transform.position + new Vector3(transform.right.x, 1, 0),
				Quaternion.identity);
			entity.transform.right = direction;
			entity.OnTriggerEnter2DAsObservable()
					.Subscribe(x => OnSkillTriggered(entity, x))
					.AddTo(entity);
			var entityRig = entity.GetComponent<Rigidbody2D>();
			entityRig.AddForce(direction * throwPower, ForceMode2D.Impulse);
			Destroy(entity, 5f);
		}

		private void OnSkillTriggered(GameObject entity, Collider2D other){
			var character = other.GetComponent<Character>();
			character?.ModifyHp(5);
			Destroy(entity);
		}
	}
}