using Script.Main.Utility;
using UnityEngine;

namespace Script.Main.Enemy{
	public class EnemyBehavior{
		private Enemy Enemy{ get; }

		private readonly EnemyStateCalculated _stateCalculated;
		
		//state
		private bool isMoving;
		

		public EnemyBehavior(Enemy enemy){
			Enemy = enemy;
			_stateCalculated = SingleRepository.Query<EnemyStateCalculated>();
		}

		public void UpdateState(){
			var closestCharacterDistance = _stateCalculated.GetClosestCharacterDistance(Enemy.ID);
			var characterPosition = _stateCalculated.GetClosestCharacterPosition(Enemy.ID);
			if(closestCharacterDistance <= 3){
				AttackBehavior(characterPosition);
				return;
			}

			ChaseBehavior(characterPosition);
		}

		private void AttackBehavior(Vector3 characterPosition){
			
		}

		private void ChaseBehavior(Vector3 characterPosition){
			
		}
	}
}