using Script.Main.Enemy.Interface;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Main.Enemy.Attack{
	public class LongRangeAttack : MonoBehaviour, IAttack{
		[SerializeField] private float attackColdDown = 0.5f;
		[SerializeField] private float attackObjectMoveSpeed = 5f;
		[SerializeField] private int attackDamage;
		[SerializeField] private GameObject preAttackObject;


		private Vector2 _attackDirection = Vector2.zero;
		private float _coldDownTimeTrack;
		private Enemy _enemy;

		private void Start(){
			_enemy = GetComponent<Enemy>();
			_coldDownTimeTrack = Time.time;
		}

		public bool IsReadyAttack(Transform targetTransform){
			var targetPosition = targetTransform.position;
			var position = transform.position;
			var direction = targetPosition - position;
			_attackDirection = direction.normalized;
			DetectAttackDirection(direction);
			return CanAttack();
		}

		public void Attack(){
			var bulletObject = Instantiate(preAttackObject, transform.position + Vector3.up, Quaternion.identity);
			bulletObject.OnTriggerEnter2DAsObservable().Subscribe(x => OnAttackObjectTriggerEnter(bulletObject, x))
					.AddTo(bulletObject);
			var bulletRigidbody = bulletObject.GetComponent<Rigidbody2D>();
			bulletRigidbody.AddForce(_attackDirection * attackObjectMoveSpeed, ForceMode2D.Impulse);
			ResetAttackColdDown();
			Destroy(bulletObject, 5f);
		}

		private void OnAttackObjectTriggerEnter(GameObject attackObject, Collider2D other){
			var modifyHp = other.GetComponent<IModifyHp>();
			modifyHp?.ModifyHp(-attackDamage);
			Destroy(attackObject);
		}

		private void DetectAttackDirection(Vector3 direction){
			if(direction.x > 0) _enemy.SetFacingDirection(true);
			if(direction.x < 0) _enemy.SetFacingDirection(false);
		}

		private bool CanAttack(){
			var currentTime = Time.time;
			return currentTime > _coldDownTimeTrack;
		}

		private void ResetAttackColdDown(){
			var currentTime = Time.time;
			_coldDownTimeTrack = currentTime + attackColdDown;
		}
	}
}