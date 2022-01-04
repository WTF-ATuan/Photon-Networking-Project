using System.Collections.Generic;
using Script.Main;
using Script.Main.Character.Event;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Script.Jiang{
	public class CameraFollow : MonoBehaviour{
		public float smoothing = 5f; //鏡頭平滑移動的速度
		private Vector3 _offset; //相機和主角之間的固定距離

		[SerializeField] [LabelText("相機最大移動距離")] [PropertyOrder(0)]
		private float maxMoveLimitX = 10f;

		private float _leftLimitX;
		private float _rightLimitX;

		private readonly List<Transform> _targets = new List<Transform>();


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
			var characterTransform = character.transform;
			_targets.Add(characterTransform);
			_offset = transform.position - GetCenterPoint();
		}

		private void FixedUpdate(){
			var targetsCount = _targets.Count;
			if(targetsCount < 1) return;
			var targetPosition = GetCenterPoint() + _offset + Vector3.up;
			var targetPositionX = targetPosition.x;
			if(targetPositionX > _rightLimitX || targetPositionX < _leftLimitX) return;
			transform.position =
					Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime); //以一定的速度，從A平滑移動到B
		}

		private Vector3 GetCenterPoint(){
			var targetsCount = _targets.Count;
			if(targetsCount == 1){
				return _targets[0].position;
			}

			var bounds = new Bounds(_targets[0].position, Vector3.zero);
			for(var i = 0; i < targetsCount; i++){
				bounds.Encapsulate(_targets[i].position);
			}

			return bounds.center;
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