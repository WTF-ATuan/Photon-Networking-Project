using Script.Main.Enemy.Detector;
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

		public void SetState(EnemyStateType state, float time){
			_state?.SetState(state, time);
		}

		//TODO
		public void Attack(Transform targetTransform){
			if(_attack == null) return;
			var isReadyAttack = _attack.IsReadyAttack(targetTransform);
			if(isReadyAttack)
				_attack.Attack();
		}

		//TODO
		public void Move(bool enable){
			_move?.Move(enable);
		}
	}
}