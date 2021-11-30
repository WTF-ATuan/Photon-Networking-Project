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

		private bool isMoving;

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
				if(!this) break;
				Behavior.UpdateState();
			}
		}

		public void ModifyHp(float amount){
			hp += amount;
			var hpBarRect = hpBar.GetComponent<RectTransform>();
			var height = hpBarRect.sizeDelta.y;
			hpBarRect.sizeDelta = new Vector2(hp - amount, height);
			if(hp <= 0){
				gameObject.SetActive(false);
			}
		}

		public void Attack(Vector3 targetPosition){
			DOTween.KillAll();
			var position = transform.position;
			var targetDirection = (targetPosition - position).normalized;
			var bullet = GameObject.CreatePrimitive(PrimitiveType.Cube);
			bullet.transform.position = position;
			bullet.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
			var rigBody = bullet.AddComponent<Rigidbody>();
			rigBody.AddForce(targetDirection * 10f, ForceMode.Impulse);
		}


		public void Move(Vector2 targetPosition, float closestCharacterDistance){
			if(isMoving) return;
			transform.DOMove(targetPosition, closestCharacterDistance)
					.OnComplete(() => isMoving = false);
		}
	}
}