using UnityEngine;

namespace Script.Main.Character{
	public class CharacterMovement : MonoBehaviour{
		private Rigidbody2D _rigidbody2D;
		private SpriteRenderer _spriteRenderer;

		private void Start(){
			_rigidbody2D = GetComponent<Rigidbody2D>();
			_spriteRenderer = GetComponent<SpriteRenderer>();
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
		
		public void VelocityMove(Vector2 velocity){
			_rigidbody2D.velocity = velocity;
		}

		public void RollMove(Vector2 targetPosition){
			_rigidbody2D.MovePosition(targetPosition);
		}

		public void SetFaceDirection(float facingValue){
			var isRight = facingValue >= 0;
			_spriteRenderer.flipX = !isRight;
		}
	}
}