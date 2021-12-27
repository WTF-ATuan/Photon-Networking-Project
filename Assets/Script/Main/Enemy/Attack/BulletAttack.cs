using Script.Main.Enemy.Interface;
using UnityEngine;

namespace Script.Main.Enemy.Attack{
	public class BulletAttack : MonoBehaviour, IAttack{
		[SerializeField] private float attackColdDown = 0.5f;
		[SerializeField] private float bulletSpeed = 5f;
		[SerializeField] private GameObject attackObject;


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
			var bulletObject = Instantiate(attackObject, transform.position + Vector3.up, Quaternion.identity);
			var bulletRigidbody = bulletObject.GetComponent<Rigidbody2D>();
			bulletRigidbody.AddForce(_attackDirection * bulletSpeed, ForceMode2D.Impulse);
			ResetAttackColdDown();
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