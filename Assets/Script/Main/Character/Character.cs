using Script.Main.Character.Event;
using Script.Main.Character.Interface;
using Script.Main.Skill;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Script.Main.Character{
	public class Character : MonoBehaviour{
		public string characterID = "123";

		private CharacterMovement _movement;
		private string _baseSkillName = "BasicArrow";
		private string _strongSkillName = "FireBall2D";

		private ICharacterAbility _characterAbility;

		private void Start(){
			_movement = GetComponent<CharacterMovement>();
			_characterAbility = GetComponent<ICharacterAbility>();
		}

		public void Move(float horizontal, float vertical){
			var speed = _characterAbility.QueryAbility(CharacterAbilityType.MoveSpeed);
			var velocity = _movement.GetMoveVelocity(horizontal, vertical, speed);
			_movement.AccelerationMove(velocity);
		}

		public void Jump(float horizontal){
			var force = _characterAbility.QueryAbility(CharacterAbilityType.JumpForce);
			var jumpDirection = _movement.GetJumpDirection(horizontal, force);
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