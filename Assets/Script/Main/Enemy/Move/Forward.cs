using Script.Main.Enemy.Interface;
using UnityEngine;

namespace Script.Main.Enemy.Move{
	public class Forward : MonoBehaviour , IMove{

		private Enemy _enemy;
		private void Start(){
			_enemy = GetComponent<Enemy>();
		}

		public void Move(bool enable){
			DetectFacing();
		}
		private void DetectFacing(){
			var targetList = _enemy.Detect<Collider2D>();
		}
	}
}