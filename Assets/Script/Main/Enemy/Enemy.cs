using System;
using System.Collections.Generic;
using DG.Tweening;
using Script.Main.Enemy.Detector;
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
		private IDetector _detector;

		private void Start(){
			ID = Guid.NewGuid().ToString();
			SingleRepository.Query<EnemyRepository>().Save(ID, this);
			_move = GetComponent<IMove>();
			_detector = GetComponent<IDetector>();
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

		//TODO
		public void SetState(EnemyStateType state, float time){
			Debug.Log($"Name.State = {state} after {time}");
		}

		public TargetList<T> Detect<T>() where T : Component{
			var detectList = _detector.Detect<T>();
			return detectList;
		}

		//TODO
		public void Attack(){
			Debug.Log($"{name} is Attacking");
		}

		//TODO
		public void SetTarget(Transform targetTransform){
			var targetName = targetTransform.name;
			Debug.Log($"my target is {targetName}");
		}
	}
}