using Script.Main.Enemy.Extension;
using Script.Main.Enemy.Interface;
using UnityEngine;

namespace Script.Main.Enemy.Move{
	public class BackAndForth : MonoBehaviour, IMove{
		[SerializeField] private bool defaultFaceDirectionIsRight;


		private Enemy _enemy;
		private bool _faceDirectionIsRight;
		private ColdDownTimer _timer;

		private void Start(){
			_enemy = GetComponent<Enemy>();
			_faceDirectionIsRight = defaultFaceDirectionIsRight;
			_enemy.SetFacingDirection(_faceDirectionIsRight);
			_timer = new ColdDownTimer(1f);
		}

		public void Move(bool enable){
			if(!enable) return;
			if(_timer.CanInvoke()){
				DetectFacing();
			}

			transform.position += _enemy.GetFacingDirection() * Time.deltaTime;
		}

		private void DetectFacing(){
			var targetList = _enemy.Detect<Collider2D>(LayerMask.NameToLayer("Ground"));
			var isEmpty = targetList.Count < 1;
			if(isEmpty) return;
			_faceDirectionIsRight = !_faceDirectionIsRight;
			_enemy.SetFacingDirection(_faceDirectionIsRight);
			_timer.ResetColdDown();
		}
	}
}