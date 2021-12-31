using Script.Main;
using Script.Main.Character.Event;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Jiang{
	public class CameraFollow : MonoBehaviour{
		public Transform player;
		public float smoothing = 5f; //鏡頭平滑移動的速度
		private Vector3 _offset; //相機和主角之間的固定距離

		[SerializeField] [LabelText("相機最大移動距離")] [PropertyOrder(0)]
		private float maxMoveLimitX = 10f;

		private float _leftLimitX;
		private float _rightLimitX;


		private void Start(){
			EventBus.Subscribe<CharacterCreated>(OnCharacterCreated);
			ProcessPatrolPositions();
		}

		private void ProcessPatrolPositions(){
			var spawnPositionX = transform.position.x;
			_leftLimitX = spawnPositionX - maxMoveLimitX;
			_rightLimitX = spawnPositionX + maxMoveLimitX;
		}

		private void OnCharacterCreated(CharacterCreated obj){
			var character = obj.Character;
			player = character.transform;
			_offset = transform.position - player.position;
		}

		private void FixedUpdate(){
			var targetPosition = player.position + _offset + Vector3.up;
			var targetPositionX = targetPosition.x;
			if(targetPositionX > _rightLimitX || targetPositionX < _leftLimitX) return;
			transform.position =
					Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime); //以一定的速度，從A平滑移動到B
		}

		private void DrawLine(float patrolX, Vector3 spawnPosition){
			var spawnPositionY = spawnPosition.y;
			var spawnPositionZ = spawnPosition.z;
			var startPoint = new Vector3(patrolX, spawnPositionY + 2f, spawnPositionZ);
			var endPoint = new Vector3(patrolX, spawnPositionY - 1f, spawnPositionZ);
			Gizmos.DrawLine(startPoint, endPoint);
		}


		private void OnDrawGizmos(){
			Gizmos.color = Color.white;
			if(Application.isPlaying == false)
				ProcessPatrolPositions();
			var position = transform.position;
			DrawLine(_leftLimitX, position);
			DrawLine(_rightLimitX, position);
		}
	}
}