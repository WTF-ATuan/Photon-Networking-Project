using Script.Main.InputData.Event;
using UnityEngine;

namespace Script.Main.Character{
	public class CharacterMovement : MonoBehaviour{
		[SerializeField] private float movementSpeed;

		private Rigidbody2D _rigidbody2D;
		private SpriteRenderer _spriteRenderer;

		public float Velocity{ get; private set; }

		private void Start(){
			_rigidbody2D = GetComponent<Rigidbody2D>();
			_spriteRenderer = GetComponent<SpriteRenderer>();
		}

		public void Move(float horizontal, float vertical){
			var velocity = new Vector2(horizontal, vertical) * movementSpeed;
			Velocity = velocity.magnitude;
			_rigidbody2D.velocity = velocity;
		}

		public void SetFaceDirection(float facingValue){
			var isRight = facingValue >= 0;
			_spriteRenderer.flipX = !isRight;
		}
	}
}