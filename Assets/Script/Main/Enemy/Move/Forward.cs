using Script.Main.Enemy.Interface;
using UnityEngine;

namespace Script.Main.Enemy.Move{
	public class Forward : MonoBehaviour , IMove{
		
		
		public void Move(bool enable){
			DetectFacing();
		}
		private void DetectFacing(){
			var positionX = transform.position.x;
			
		}
	}
}