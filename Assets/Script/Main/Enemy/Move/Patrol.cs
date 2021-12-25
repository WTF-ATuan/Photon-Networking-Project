using Script.Main.Enemy.Interface;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Script.Main.Enemy.Move{
	[RequireComponent(typeof(Enemy))]
	public class Patrol : MonoBehaviour, IMove{
		[SerializeField] [LabelText("巡邏的間距")] [PropertyOrder(0)]
		private float patrolOffsetX = 3f;

		[SerializeField] [ReadOnly] [BoxGroup("ReadOnly")]
		private float leftPatrolX;

		[SerializeField] [ReadOnly] [BoxGroup("ReadOnly")]
		private float rightPatrolX;

		private Enemy _enemy;

		private Vector3 _spawnPosition;

		private void Start(){
			_enemy = GetComponent<Enemy>();
			ProcessPatrolPositions();
		}

		private void ProcessPatrolPositions(){
			_spawnPosition = transform.position;
			var spawnPositionX = _spawnPosition.x;
			leftPatrolX = spawnPositionX - patrolOffsetX;
			rightPatrolX = spawnPositionX + patrolOffsetX;
		}

		public void Move(bool enable){
			if(!enable) return;
			DetectFacing();
			transform.position += _enemy.GetFacingDirection() * Time.deltaTime;
		}

		private void DetectFacing(){
			var positionX = transform.position.x;
			if(positionX < leftPatrolX) _enemy.SetFacingDirection(true);
			if(positionX > rightPatrolX) _enemy.SetFacingDirection(false);
		}

		private void DrawLine(float patrolX, Vector3 spawnPosition){
			var spawnPositionY = spawnPosition.y;
			var spawnPositionZ = spawnPosition.z;
			var startPoint = new Vector3(patrolX, spawnPositionY + 2f, spawnPositionZ);
			var endPoint = new Vector3(patrolX, spawnPositionY - 1f, spawnPositionZ);
			Gizmos.DrawLine(startPoint, endPoint);
		}


		private void OnDrawGizmos(){
			Gizmos.color = Color.magenta;
			if(Application.isPlaying == false)
				ProcessPatrolPositions();
			DrawLine(leftPatrolX, _spawnPosition);
			DrawLine(rightPatrolX, _spawnPosition);
		}
	}
}