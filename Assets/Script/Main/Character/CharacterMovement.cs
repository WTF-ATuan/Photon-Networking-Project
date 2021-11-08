using Sirenix.OdinInspector;
using UnityEngine;

namespace Script.Main.Character{
	public class CharacterMovement : MonoBehaviour{
		public float movementSpeed;

		private Rigidbody2D _rigidbody2D;
		private SpriteRenderer _spriteRenderer;

		private void Start(){
			_rigidbody2D = GetComponent<Rigidbody2D>();
			_spriteRenderer = GetComponent<SpriteRenderer>();
		}

		public void Move(float horizontal, float vertical){
			var velocity = new Vector2(horizontal, vertical) * movementSpeed;
			_rigidbody2D.velocity = velocity;
		}
		public void TumbleRoll(Vector2 direction , float force){
			Vector3 rollForce = direction * force;
			var targetPosition = transform.position + rollForce;
			_rigidbody2D.MovePosition(targetPosition);
		}

		public void SetFaceDirection(float facingValue){
			var isRight = facingValue >= 0;
			_spriteRenderer.flipX = !isRight;
		}
	}
}