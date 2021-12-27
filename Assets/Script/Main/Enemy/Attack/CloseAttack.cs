using Script.Main.Enemy.Interface;
using UnityEngine;

namespace Script.Main.Enemy.Attack{
	public class CloseAttack : MonoBehaviour, IAttack{
		[SerializeField] private float attackColdDown = 0.5f;


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
			DetectAttackDirection(direction);
			return CanAttack();
		}

		public void Attack(){
			var targetList = _enemy.Detect<Character.Character>();
			var closestTarget = targetList.GetClosestTarget(transform.position);
			closestTarget.ModifyHp(-10);
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