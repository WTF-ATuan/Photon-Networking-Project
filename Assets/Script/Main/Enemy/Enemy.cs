using System;
using DG.Tweening;
using Script.Main.Enemy.Interface;
using Script.Main.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Main.Enemy{
	public class Enemy : MonoBehaviour, IModifyHp{
		public string ID{ get; private set; }

		[SerializeField] private float hp = 100;
		[SerializeField] private Image hpBar;

		private IMove _move;

		private void Start(){
			ID = Guid.NewGuid().ToString();
			SingleRepository.Query<EnemyRepository>().Save(ID, this);
			_move = GetComponent<IMove>();
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

		public void Move(bool enable, Vector2 direction){
			_move?.Move(enable, direction);
		}

		public void SetFacingDirection(bool isRight){
			var localScale = transform.localScale;
			var localScaleX = localScale.x;
			var isLeft = localScaleX > 0;
			if(isRight){
				localScaleX = isLeft ? localScaleX * -1 : localScaleX * 1;
				localScale.x = localScaleX;
				transform.localScale = localScale;
			}
			else{
				localScaleX = isLeft ? localScaleX * 1 : localScaleX * -1;
				localScale.x = localScaleX;
				transform.localScale = localScale;
			}
		}

		public void SetState(EnemyStateType state, float time){
			Debug.Log($"Name.State = {state} after {time}");
		}
	}
}