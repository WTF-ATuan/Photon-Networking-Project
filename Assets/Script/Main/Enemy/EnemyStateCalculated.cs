﻿using System;
using Script.Main.Character;
using Script.Main.Utility;
using UnityEngine;
using WebSocketSharp;

namespace Script.Main.Enemy{
	public class EnemyStateCalculated{
		private readonly CharacterRepository _characterRepository;
		private readonly EnemyRepository _enemyRepository;

		public EnemyStateCalculated(){
			_enemyRepository = SingleRepository.Query<EnemyRepository>();
			_characterRepository = SingleRepository.Query<CharacterRepository>();
		}

		public Vector3 GetClosestCharacterPosition(string enemyID){
			if(enemyID.IsNullOrEmpty()) throw new Exception("The enemyID is empty");
			var closestCharacter = GetClosestCharacter(enemyID);
			var position = closestCharacter ? closestCharacter.transform.position : Vector3.zero;
			return position;
		}

		public float GetClosestCharacterDistance(string enemyID){
			if(enemyID.IsNullOrEmpty()) throw new Exception("The enemyID is empty");
			var enemy = _enemyRepository.Query(enemyID);
			var closestCharacter = GetClosestCharacter(enemyID);
			var enemyPosition = enemy.transform.position;
			var characterPosition = closestCharacter.transform.position;
			var distance = Vector3.Distance(characterPosition, enemyPosition);
			return distance;
		}

		private Character.Character GetClosestCharacter(string enemyID){
			if(enemyID.IsNullOrEmpty()) throw new Exception("The enemyID is empty");
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

			return closestCharacter;
		}
	}
}