using Script.Main.Character.Event;
using Script.Main.Character.Interface;
using Script.Main.Skill;
using UnityEngine;

namespace Script.Main.Character{
	public class Character : MonoBehaviour{
		public string characterID = "123";

		private string _baseSkillName = "BasicArrow";
		private string _strongSkillName = "FireBall2D";

		private ICharacterAbility _characterAbility;
		private IGround _groundCheck;
		private IJump _jump;

		private Rigidbody2D _rigidbody2D;

		private void Start(){
			_rigidbody2D = GetComponent<Rigidbody2D>();
			_characterAbility = GetComponent<ICharacterAbility>();
			_groundCheck = GetComponent<IGround>();
			_jump = GetComponent<IJump>();
		}

		public void Move(float horizontal, float vertical){
			var speed = _characterAbility.QueryAbility(CharacterAbilityType.MoveSpeed);
			var acceleration = new Vector2(horizontal, vertical) * speed;
			var currentVelocity = _rigidbody2D.velocity;
			var nextVelocity = new Vector2(acceleration.x, currentVelocity.y);
			_rigidbody2D.velocity = nextVelocity;
		}

		public void Jump(float horizontal){
			var canJump = _jump.CanJump(_groundCheck);
			if(!canJump) return;
			var force = _characterAbility.QueryAbility(CharacterAbilityType.JumpForce);
			_jump.Jump(horizontal, force);
		}


		public void SetFaceDirection(float direction){
			if(direction == 0) return;
			var isRight = direction < 0;
			var localScale = transform.localScale;
			var localScaleX = localScale.x;
			var isLeft = localScaleX > 0;
			if(isRight){
				localScaleX = isLeft ? localScaleX * -1 : localScaleX * 1;
				localScale.x = localScaleX;
				transform.localScale = localScale;
			}
			else{
				localScaleX = isLeft ? localScaleX * 1 : localScaleX * -1;
				localScale.x = localScaleX;
				transform.localScale = localScale;
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