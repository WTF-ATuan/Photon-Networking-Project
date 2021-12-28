﻿using Script.Main.Enemy.Detector;
using Script.Main.Enemy.Event;
using Script.Main.Enemy.Interface;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Main.Enemy{
	public class Enemy : MonoBehaviour, IModifyHp{
		[SerializeField] private float hp = 100;
		[SerializeField] private Image hpBar;

		private IDetector _detector;
		private IState _state;
		private IMove _move;
		private IAttack _attack;


		private void Start(){
			_detector = GetComponent<IDetector>();
			_state = GetComponent<IState>();
			_move = GetComponent<IMove>();
			_attack = GetComponent<IAttack>();
		}


		public void ModifyHp(float amount){
			hp += amount;
			var hpBarRect = hpBar.GetComponent<RectTransform>();
			var height = hpBarRect.sizeDelta.y;
			hpBarRect.sizeDelta = new Vector2(hp - amount, height);
			if(hp <= 0){
				gameObject.SetActive(false);
				var id = gameObject.GetInstanceID().ToString();
				var enemyDead = new EnemyDead(id);
				EventBus.Post(enemyDead);
			}
		}

		public Vector3 GetFacingDirection(){
			var localScale = transform.localScale;
			var localScaleX = localScale.x;
			var isLeft = localScaleX > 0;
			var direction = isLeft ? Vector2.left : Vector2.right;
			return direction;
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

		public TargetList<T> Detect<T>(int layer = default) where T : Component{
			var detectList = _detector?.Detect<T>(layer);
			return detectList ?? new TargetList<T>();
		}

		public void SetState(EnemyStateType state, float time){
			_state?.SetState(state, time);
		}

		public void Attack(Transform targetTransform){
			if(_attack == null) return;
			var isReadyAttack = _attack.IsReadyAttack(targetTransform);
			if(isReadyAttack)
				_attack.Attack();
		}

		public void Move(bool enable){
			_move?.Move(enable);
		}
	}
}