using Script.Main.Character.Interface;
using Script.Main.Enemy;
using Script.Main.Enemy.Extension;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Script.Main.Character.Attack{
	public class Shield : MonoBehaviour, IAttack{
		[SerializeField] private GameObject shieldPre;
		[SerializeField] private float throwPower;
		[SerializeField] private float coldDown = 1f;
		

		private Character _character;
		private ColdDownTimer _timer;

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
			var entity = Instantiate(shieldPre, transform.position + new Vector3(transform.right.x, 1, 0),
				Quaternion.identity);
			entity.transform.right = attackDirection;
			entity.OnTriggerEnter2DAsObservable()
					.Subscribe(x => OnSkillTriggered(entity, x))
					.AddTo(entity);
			var entityRig = entity.GetComponent<Rigidbody2D>();
			entityRig.AddForce(attackDirection * throwPower, ForceMode2D.Impulse);
			_timer.Reset();
			Destroy(entity, 5f);
		}

		private void OnSkillTriggered(GameObject shield, Collider2D other){
			var enemy = other.GetComponent<Enemy.Enemy>();
			if(enemy == null) return;
			enemy.SetState(EnemyStateType.Dizzy, 1);
			enemy.ModifyHp(-10);
		}
	}
}