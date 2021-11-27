using System;
using System.Threading.Tasks;
using DG.Tweening;
using Script.Main.Enemy.Interface;
using Script.Main.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Main.Enemy{
	public class Enemy : MonoBehaviour, IModifyHp{
		public string ID{ get; private set; }
		public EnemyBehavior Behavior{ get; private set; }

		[SerializeField] private float hp = 100;
		[SerializeField] private Image hpBar;

		private void Start(){
			var enemyRepository = SingleRepository.Query<EnemyRepository>();
			ID = Guid.NewGuid().ToString();
			enemyRepository.Save(ID, this);
			Behavior = new EnemyBehavior(this);
			UpdateState();
		}

		private async void UpdateState(){
			while(enabled){
				await Task.Delay(1500);
				Behavior.UpdateState();
			}
		}

		public void ModifyHp(float amount){
			hp += amount;
			hpBar.GetComponent<RectTransform>().sizeDelta = new Vector2(hp - amount, 10);
			if(hp <= 0){
				gameObject.SetActive(false);
			}
		}

		public void Attack(Vector3 targetPosition){ }

		public void Move(Vector2 targetPosition, float closestCharacterDistance){
			transform.DOMove(targetPosition, closestCharacterDistance);
		}
	}
}