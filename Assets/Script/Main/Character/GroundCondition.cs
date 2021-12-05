using Script.Main.Character.Interface;
using UnityEngine;

namespace Script.Main.Character{
	public class GroundCondition : MonoBehaviour , IGround{
		private Collider2D _collider;
		[SerializeField] private float distance = 0.5f;
		[SerializeField] private LayerMask groundLayer;


		private void Start(){
			_collider = GetComponent<Collider2D>();
		}

		public bool IsGrounded(){
			var colliderBounds = _collider.bounds;
			var raycastHit2D = Physics2D.BoxCast(colliderBounds.center, colliderBounds.size, 0f, Vector2.down, distance,
				groundLayer);
			var hitCollider = raycastHit2D.collider;
			var isGround = hitCollider != null;
			return isGround;
		}

		private void OnDrawGizmos(){
			var colliderBounds = _collider.bounds;
			var rayColor = IsGrounded() ? Color.green : Color.red;
			Debug.DrawRay(colliderBounds.center + new Vector3(colliderBounds.extents.x, 0),
				Vector2.down * (colliderBounds.extents.y + distance), rayColor);
			Debug.DrawRay(colliderBounds.center - new Vector3(colliderBounds.extents.x, 0),
				Vector2.down * (colliderBounds.extents.y + distance), rayColor);
			Debug.DrawRay(
				colliderBounds.center - new Vector3(colliderBounds.extents.x, colliderBounds.extents.y + distance),
				Vector2.right * (colliderBounds.extents.x * 2), rayColor);
		}
	}
}