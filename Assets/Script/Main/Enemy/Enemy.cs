using System;
using Script.Main.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Main.Enemy{
	public class Enemy : MonoBehaviour, IModifyHp{
		public string ID{ get; private set; }
		public EnemyStateDetermination StateDetermination{ get; private set; }

		[SerializeField] private float hp = 100;
		[SerializeField] private Image hpBar;

		private void Start(){
			var enemyRepository = SingleRepository.Query<EnemyRepository>();
			ID = Guid.NewGuid().ToString();
			enemyRepository.Save(ID, this);
			StateDetermination = new EnemyStateDetermination(this);
		}

		private void Update(){
			StateDetermination.UpdateState();
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