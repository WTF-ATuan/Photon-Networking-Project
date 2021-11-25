using System;
using Script.Main.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Main.Enemy{
	public class Enemy : MonoBehaviour, IModifyHp{
		public float hp = 100;
		public Image hpBar;
		private EnemyStateCalculate _stateCalculate;

		private void Start(){
			var enemyRepository = SingleRepository.Query<EnemyRepository>();
			var id = Guid.NewGuid().ToString();
			enemyRepository.Save(id, this);
			_stateCalculate = SingleRepository.Query<EnemyStateCalculate>();
		}

		private void Update(){
			
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