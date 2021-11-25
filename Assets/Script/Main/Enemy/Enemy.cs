using System;
using Script.Main.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Main.Enemy{
	public class Enemy : MonoBehaviour, IModifyHp{
		public float hp = 100;
		public Image hpBar;

		private string _id;
		private EnemyStateCalculated _stateCalculated;

		private void Start(){
			var enemyRepository = SingleRepository.Query<EnemyRepository>();
			_id = Guid.NewGuid().ToString();
			enemyRepository.Save(_id, this);
			_stateCalculated = SingleRepository.Query<EnemyStateCalculated>();
		}

		private void Update(){
			var closestCharacterDistance = _stateCalculated.GetClosestCharacterDistance(_id);
			if(closestCharacterDistance < 3){
				Debug.Log($"Attack");
			}

			if(closestCharacterDistance > 3){
				Debug.Log($"Move~~");
			}
		}

		public void ModifyHp(float amount){
			hp += amount;
			hpBar.GetComponent<RectTransform>().sizeDelta = new Vector2(hp - amount, 10);
			if(hp <= 0){
				gameObject.SetActive(false);
			}
		}
	}

	public interface IModifyHp{
		void ModifyHp(float amount);
	}
}