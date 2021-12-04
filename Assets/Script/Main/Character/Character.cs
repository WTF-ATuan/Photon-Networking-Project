using Script.Main.Character.Event;
using Script.Main.Skill;
using UnityEngine;

namespace Script.Main.Character{
	public class Character : MonoBehaviour{
		public string characterID = "123";

		private CharacterMovement _movement;
		private string _baseSkillName = "BasicArrow";
		private string _strongSkillName = "FireBall2D";

		[SerializeField] private float jumpForce;
		[SerializeField] private float moveSpeed = 3;

		private void Start(){
			_movement = GetComponent<CharacterMovement>();
		}

		public void Move(float horizontal, float vertical){
			var velocity = _movement.GetMoveVelocity(horizontal, vertical, moveSpeed);
			_movement.VelocityMove(velocity);
		}

		public void Jump(float horizontal){
			var jumpDirection = _movement.GetJumpDirection(horizontal, jumpForce);
			_movement.Jump(jumpDirection);
		}

		public void TumbleRoll(float horizontal, float vertical){
			var direction = new Vector2(horizontal, vertical);
			var targetPosition = _movement.GetRollTargetPosition(transform.position, direction, 2);
			_movement.RollMove(targetPosition);
		}

		public void SetFaceDirection(float direction){
			if(direction != 0){
				_movement.SetFaceDirection(direction);
			}
		}

		public void CastSkill(Vector2 targetPosition, bool isBase){
			var direction = (targetPosition - (Vector2)transform.position).normalized;
			if(isBase){
				EventBus.Post(new SkillCasted(_baseSkillName,
					new SkillSpawnInfo(characterID, transform.position, direction)));
			}
			else{
				EventBus.Post(new SkillCasted(_strongSkillName,
					new SkillSpawnInfo(characterID, transform.position, direction)));
			}
		}
	}
}