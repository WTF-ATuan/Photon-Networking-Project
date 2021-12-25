using Script.Main.Enemy.Interface;
using UnityEngine;

namespace Script.Main.Enemy.Move{
	public class BackAndForth : MonoBehaviour, IMove{
		[SerializeField] private bool defaultFaceDirectionIsRight;


		private Enemy _enemy;
		private bool _faceDirectionIsRight;

		private void Start(){
			_enemy = GetComponent<Enemy>();
			_faceDirectionIsRight = defaultFaceDirectionIsRight;
			_enemy.SetFacingDirection(_faceDirectionIsRight);
		}

		public void Move(bool enable){
			DetectFacing();
			transform.position += _enemy.GetFacingDirection() * Time.deltaTime;
		}

		private void DetectFacing(){
			var targetList = _enemy.Detect<Collider2D>();
			var isEmpty = targetList.Count < 1;
			if(isEmpty) return;
			_enemy.SetFacingDirection(_faceDirectionIsRight);
		}
	}
}