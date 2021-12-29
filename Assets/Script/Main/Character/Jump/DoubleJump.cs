using Script.Main.Character.Event;
using Script.Main.Character.Interface;
using UnityEngine;

namespace Script.Main.Character.Jump{
	[RequireComponent(typeof(Rigidbody2D))]
	public class DoubleJump : MonoBehaviour, IJump{
		private Rigidbody2D _rigidbody2D;
		private int _jumpCount = 0;
		private Character _character;

		private void Start(){
			_character = GetComponent<Character>();
			_rigidbody2D = GetComponent<Rigidbody2D>();
		}

		public bool CanJump(IGround groundCondition){
			var isGrounded = groundCondition.IsGrounded();
			if(isGrounded){
				_jumpCount = 0;
				return true;
			}

			return _jumpCount <= 1;
		}

		public void Jump(float directionX, float jumpForce){
			var jumpDirection = new Vector2(directionX, 1f) * jumpForce;
			_rigidbody2D.AddForce(jumpDirection, ForceMode2D.Impulse);
			_character.PlayAnimation("Jump", 2);
			_jumpCount++;
		}
	}
}