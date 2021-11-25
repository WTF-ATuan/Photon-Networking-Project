using Script.Main.Utility;
using UnityEngine;

namespace Script.Main.Enemy{
	public class EnemyStateDetermination{
		private Enemy Enemy{ get; }

		private readonly EnemyStateCalculated _stateCalculated;

		public EnemyStateDetermination(Enemy enemy){
			Enemy = enemy;
			_stateCalculated = SingleRepository.Query<EnemyStateCalculated>();
		}

		public void UpdateState(){
			var closestCharacterDistance = _stateCalculated.GetClosestCharacterDistance(Enemy.ID);
			var characterPosition = _stateCalculated.GetClosestCharacterPosition(Enemy.ID);
			if(closestCharacterDistance < 3){
				Debug.Log($"Attack");
				Enemy.Attack(characterPosition);
			}

			if(closestCharacterDistance > 3){
				Debug.Log($"Move~~");
				var movePosition = (Vector2)characterPosition + Random.insideUnitCircle * 3;
				Enemy.Move(movePosition);
			}
		}
	}
}