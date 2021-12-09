﻿using Script.Main.Enemy.Detector;
using Script.Main.Enemy.Interface;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Main.Enemy{
	public class Enemy : MonoBehaviour, IModifyHp{
		[SerializeField] private float hp = 100;
		[SerializeField] private Image hpBar;

		private IDetector _detector;
		private IState _state;

		private void Start(){
			_detector = GetComponent<IDetector>();
			_state = GetComponent<IState>();
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

		public TargetList<T> Detect<T>() where T : Component{
			var detectList = _detector?.Detect<T>();
			return detectList ?? new TargetList<T>();
		}

		//TODO
		public void SetState(EnemyStateType state, float time){
			Debug.Log($"Name.State = {state} after {time}");
			_state?.SetState(state , time);
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