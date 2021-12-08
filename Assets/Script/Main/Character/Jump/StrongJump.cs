using System;
using Script.Main.Character.Interface;
using Script.Main.Enemy;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Script.Main.Character.Jump{
	[RequireComponent(typeof(Rigidbody2D))]
	public class StrongJump : MonoBehaviour, IJump{
		private Rigidbody2D _rigidbody2D;
		[SerializeField] private int dizzyRange;
		[SerializeField] [ReadOnly] private Vector2 limitPointLeft;
		[SerializeField] [ReadOnly] private Vector2 limitPointRight;


		private void Start(){
			_rigidbody2D = GetComponent<Rigidbody2D>();
		}

		private void ProgressDizzyRange(){
			var dizzyOffsetX = dizzyRange / 2;
			var position = transform.position;
			limitPointLeft = new Vector2(position.x - dizzyOffsetX, position.y);
			limitPointRight = new Vector2(position.x + dizzyOffsetX, position.y);
		}

		public bool CanJump(IGround groundCondition){
			var isGrounded = groundCondition.IsGrounded();
			return isGrounded;
		}

		public void Jump(float directionX, float jumpForce){
			ProgressDizzyRange();
			var jumpDirection = new Vector2(directionX, 1f) * jumpForce;
			_rigidbody2D.AddForce(jumpDirection, ForceMode2D.Impulse);
			Dizzy();
		}

		private void Dizzy(){
			// ReSharper disable once Unity.PreferNonAllocApi
			var raycastHit2D = Physics2D.LinecastAll(limitPointLeft, limitPointRight);
			foreach(var raycastHit in raycastHit2D){
				var hitCollider = raycastHit.collider;
				var enemy = hitCollider.GetComponent<Enemy.Enemy>();
				enemy?.SetState(EnemyStateType.Dizzy, 3f);
			}
		}

		private void OnDrawGizmos(){
			Gizmos.color = Color.blue;
			Gizmos.DrawLine(limitPointLeft, limitPointLeft + (Vector2.up) / 2);
			Gizmos.DrawLine(limitPointRight, limitPointRight + (Vector2.up) / 2);
		}
	}
}