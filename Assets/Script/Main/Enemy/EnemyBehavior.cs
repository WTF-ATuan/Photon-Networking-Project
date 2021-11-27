using Script.Main.Utility;
using UnityEngine;

namespace Script.Main.Enemy{
	public class EnemyBehavior{
		private Enemy Enemy{ get; }

		private readonly EnemyStateCalculated _stateCalculated;

		public EnemyBehavior(Enemy enemy){
			Enemy = enemy;
			_stateCalculated = SingleRepository.Query<EnemyStateCalculated>();
		}

		public void UpdateState(){
			var closestCharacterDistance = _stateCalculated.GetClosestCharacterDistance(Enemy.ID);
			var characterPosition = _stateCalculated.GetClosestCharacterPosition(Enemy.ID);
			if(closestCharacterDistance <= 3){
				Enemy.Attack(characterPosition);
				return;
			}

			var movePosition = (Vector2)characterPosition + Random.insideUnitCircle * 3;
			Enemy.Move(movePosition);
		}
	}
}