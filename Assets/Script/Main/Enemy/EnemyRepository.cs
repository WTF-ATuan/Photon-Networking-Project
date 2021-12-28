using System;
using System.Collections.Generic;

namespace Script.Main.Enemy{
	public class EnemyRepository{
		private readonly Dictionary<string, Enemy> _enemyList = new Dictionary<string, Enemy>();

		public void Save(string enemyID, Enemy enemy){
			var containsKey = _enemyList.ContainsKey(enemyID);
			if(containsKey){
				throw new Exception($"Enemy : {enemyID} have same ID ");
			}

			_enemyList.Add(enemyID, enemy);
		}

		public Enemy Query(string enemyID){
			var containsKey = _enemyList.ContainsKey(enemyID);
			if(!containsKey) throw new Exception($"can,t Find this Enemy : {enemyID}");
			var Enemy = _enemyList[enemyID];
			return Enemy;
		}

		public void Remove(string enemyID){
			var containsKey = _enemyList.ContainsKey(enemyID);
			if(!containsKey){
				throw new Exception($"{enemyID} Not Found ");
			}

			_enemyList.Remove(enemyID);
		}

		public int Count(){
			return _enemyList.Count;
		}
	}
}