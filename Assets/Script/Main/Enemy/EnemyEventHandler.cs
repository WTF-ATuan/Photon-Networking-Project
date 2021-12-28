using System;
using Script.Main.Enemy.Event;
using Script.Main.Utility;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Script.Main.Enemy{
	public class EnemyEventHandler : MonoBehaviour{
		private EnemyRepository _repository;
		[SerializeField] private UnityEvent onEnemyAllDead;

		private void Start(){
			_repository = SingleRepository.Query<EnemyRepository>();
			EventBus.Subscribe<EnemyDead>(OnEnemyDead);
		}

		private void OnEnemyDead(EnemyDead obj){
			var enemyID = obj.EnemyID;
			_repository.Remove(enemyID);
			var isEmpty = _repository.Count() < 1;
			Debug.LogWarning(_repository.Count());
			if(isEmpty){
				onEnemyAllDead?.Invoke();
			}
		}
	}
}