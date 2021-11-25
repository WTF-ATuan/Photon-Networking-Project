using Script.Main.Character;
using Script.Main.Utility;
using UnityEngine;

namespace Script.Main.Enemy{
	public class EnemyBehavior{
		private readonly CharacterRepository _characterRepository;
		private readonly EnemyRepository _enemyRepository;

		public EnemyBehavior(){
			_enemyRepository = SingleRepository.Query<EnemyRepository>();
			_characterRepository = SingleRepository.Query<CharacterRepository>();
		}

		public Vector3 GetClosestCharacterPosition(string enemyID){
			var enemy = _enemyRepository.Query(enemyID);
			var enemyPosition = enemy.transform.position;
			var characters = _characterRepository.QueryAll();
			var minDistance = float.PositiveInfinity;
			Character.Character closestCharacter = null;
			foreach(var character in characters){
				var characterPosition = character.transform.position;
				var distance = Vector3.Distance(characterPosition, enemyPosition);
				if(!(distance < minDistance)) continue;
				closestCharacter = character;
				minDistance = distance;
			}

			var position = closestCharacter ? closestCharacter.transform.position : Vector3.zero;

			return position;
		}

		public float GetDistanceOfCharacter(string enemyID, string characterID){
			var enemy = _enemyRepository.Query(enemyID);
			var character = _characterRepository.Query(characterID);
			var enemyPosition = enemy.transform.position;
			var characterPosition = character.transform.position;
			var distance = Vector3.Distance(characterPosition, enemyPosition);
			return distance;
		}
	}
}