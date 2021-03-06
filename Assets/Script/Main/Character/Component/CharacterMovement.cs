using UnityEngine;

namespace Script.Main.Character{
	public class CharacterMovement : MonoBehaviour{
		private Rigidbody2D _rigidbody2D;

		private void Start(){
			_rigidbody2D = GetComponent<Rigidbody2D>();
		}

		public Vector2 GetMoveVelocity(float horizontal, float vertical, float speed){
			var velocity = new Vector2(horizontal, vertical) * speed;
			return velocity;
		}

		public Vector2 GetRollTargetPosition(Vector2 originPosition, Vector2 direction, float force){
			var rollForce = direction * force;
			var targetPosition = originPosition + rollForce;
			return targetPosition;
		}

		public void AccelerationMove(Vector2 acceleration){
			var currentVelocity = _rigidbody2D.velocity;
			var nextVelocity = new Vector2(acceleration.x, currentVelocity.y);
			_rigidbody2D.velocity = nextVelocity;
		}

		public void RollMove(Vector2 targetPosition){
			_rigidbody2D.MovePosition(targetPosition);
		}
		
		
	}
}