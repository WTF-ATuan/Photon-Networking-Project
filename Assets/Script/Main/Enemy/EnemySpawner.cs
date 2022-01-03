using System.Collections.Generic;
using Script.Main.Enemy.Extension;
using Script.Main.Utility;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Script.Main.Enemy{
	public class EnemySpawner : MonoBehaviour{
		[SerializeField] [BoxGroup("Basic")] private List<Enemy> randomEnemyType;
		[SerializeField] [BoxGroup("Basic")] private List<int> waveEnemyCount = new List<int>();
		[SerializeField] [BoxGroup("Basic")] private float spawnDuring;

		[SerializeField] [LabelText("隨機生成範圍")] [PropertyOrder(0)]
		private float spawnSize = 3f;

		[SerializeField] [ReadOnly] [BoxGroup("ReadOnly")]
		private float leftLimitX;

		[SerializeField] [ReadOnly] [BoxGroup("ReadOnly")]
		private float rightLimitX;


		private int _currentWave;
		private int _currentWaveEnemyCount;
		private ColdDownTimer _timer;
		private EnemyRepository _repository;

		private void Start(){
			_timer = new ColdDownTimer(spawnDuring);
			_repository = SingleRepository.Query<EnemyRepository>();
			ProcessPositions();
		}

		private void ProcessPositions(){
			var spawnPositionX = transform.position.x;
			leftLimitX = spawnPositionX - spawnSize;
			rightLimitX = spawnPositionX + spawnSize;
		}

		private void FixedUpdate(){
			if(_timer.CanInvoke()){
				Spawn();
			}
		}

		public void Spawn(){
			var enemyTypeCount = randomEnemyType.Count;
			var range = Random.Range(0, enemyTypeCount);
			var spawnEnemy = randomEnemyType[range];
			if(_currentWave >= waveEnemyCount.Count) return;
			var maxEnemyCount = waveEnemyCount[_currentWave];
			var randomPosition = RandomSpawnPosition();
			var enemy = Instantiate(spawnEnemy, randomPosition, Quaternion.identity);
			var enemyID = enemy.GetInstanceID().ToString();
			enemy.EnemyID = enemyID;
			_repository.Save(enemyID, enemy);
			if(_currentWaveEnemyCount >= maxEnemyCount){
				_currentWave++;
				_currentWaveEnemyCount = 1;
			}
			else{
				_currentWaveEnemyCount++;
			}

			_timer.Reset();
		}

		private Vector2 RandomSpawnPosition(){
			var spawnPositionX = Random.Range(leftLimitX, rightLimitX);
			var spawnPositionY = transform.position.y;
			var randomPosition = new Vector2(spawnPositionX, spawnPositionY);
			return randomPosition;
		}

		private void DrawLine(float patrolX, Vector3 spawnPosition){
			var spawnPositionY = spawnPosition.y;
			var spawnPositionZ = spawnPosition.z;
			var startPoint = new Vector3(patrolX, spawnPositionY + 2f, spawnPositionZ);
			var endPoint = new Vector3(patrolX, spawnPositionY - 1f, spawnPositionZ);
			Gizmos.DrawLine(startPoint, endPoint);
		}


		private void OnDrawGizmos(){
			Gizmos.color = Color.yellow;
			if(Application.isPlaying == false)
				ProcessPositions();
			var position = transform.position;
			DrawLine(leftLimitX, position);
			DrawLine(rightLimitX, position);
		}
	}
}