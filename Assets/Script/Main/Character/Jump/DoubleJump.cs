using Script.Main.Character.Interface;
using UnityEngine;

namespace Script.Main.Character.Jump{
	public class DoubleJump : MonoBehaviour , IJump{
		
		public bool CanJump(IGround groundCondition){
			throw new System.NotImplementedException();
		}

		public void Jump(float directionX, float jumpForce){
			throw new System.NotImplementedException();
		}
	}
}