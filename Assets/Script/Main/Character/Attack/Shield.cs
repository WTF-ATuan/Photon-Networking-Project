using Script.Main.Character.Interface;
using Script.Main.Enemy;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Script.Main.Character.Attack{
	public class Shield : MonoBehaviour, IAttack{
		[SerializeField] private GameObject shieldPre;
		private Character _character;
		[SerializeField] private float throwPower;

		private void Start(){
			_character = GetComponent<Character>();
		}

		public bool CanAttack(){
			return true;
		}

		public void Attack(Vector2 attackDirection, Vector2 targetPosition){
			_character.PlayAnimation("Attack", 1);
			var entity = Instantiate(shieldPre, transform.position + new Vector3(transform.right.x, 1, 0),
				Quaternion.identity);
			entity.transform.right = attackDirection;
			entity.OnTriggerEnter2DAsObservable()
					.Subscribe(x => OnSkillTriggered(entity, x))
					.AddTo(entity);
			var entityRig = entity.GetComponent<Rigidbody2D>();
			entityRig.AddForce(attackDirection * throwPower, ForceMode2D.Impulse);
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