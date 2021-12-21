using Script.Main.Character.Event;
using Script.Main.Character.Event.ViewEvent;
using Script.Main.Character.Interface;
using Script.Main.Skill;
using Sirenix.OdinInspector;
using Spine.Unity;
using UnityEngine;

namespace Script.Main.Character{
	public class Character : MonoBehaviour{
		[ReadOnly] public string characterID = "BIG_BOSS";
		[SerializeField] private int defaultHealth = 100;
		private int _currentHealth;


		private string _baseSkillName = "BasicArrow";
		private string _strongSkillName = "FireBall2D";

		private ICharacterAbility _characterAbility;
		private IGround _groundCheck;
		private IJump _jump;

		private Rigidbody2D _rigidbody2D;
		private SkeletonAnimation _animation;

		public void Initialize(){
			_rigidbody2D = GetComponent<Rigidbody2D>();
			_animation = GetComponent<SkeletonAnimation>();
			_characterAbility = GetComponent<ICharacterAbility>();
			_groundCheck = GetComponent<IGround>();
			_jump = GetComponent<IJump>();
			_currentHealth = defaultHealth;
		}

		public void Move(float horizontal, float vertical){
			var speed = _characterAbility.QueryAbility(CharacterAbilityType.MoveSpeed);
			var acceleration = new Vector2(horizontal, vertical) * speed;
			var currentVelocity = _rigidbody2D.velocity;
			var nextVelocity = new Vector2(acceleration.x, currentVelocity.y);
			_rigidbody2D.velocity = nextVelocity;
			if(nextVelocity == Vector2.zero){
				PlayAnimation("idle", 1);
			}
			else{
				PlayAnimation("Run", 2);
			}
			EventBus.Post(new PositionUpdated(characterID, transform.position));
		}

		public void Jump(float horizontal){
			var canJump = _jump.CanJump(_groundCheck);
			if(!canJump) return;
			var force = _characterAbility.QueryAbility(CharacterAbilityType.JumpForce);
			_jump.Jump(horizontal, force);
		}


		public void SetFaceDirection(float direction){
			if(direction == 0) return;
			var isLeft = direction < 0;
			var rightRotation = Vector3.zero;
			var leftRotation = new Vector3(0, 180, 0);
			var characterTransform = transform;
			characterTransform.eulerAngles = isLeft ? leftRotation : rightRotation;
			EventBus.Post(new FaceDirectionFlipped(characterID, characterTransform.eulerAngles));
		}

		public void ModifyAbility(CharacterAbilityType ability, float amount){
			_characterAbility.ModifyAbility(ability, amount);
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

		[Button]
		public void PlayAnimation(string animationName, float animationTimeScale){
			_animation.AnimationName = animationName;
			_animation.timeScale = animationTimeScale;
		}

		//TODO
		public void Die(){
			gameObject.SetActive(false);
		}

		public void ModifyHp(int amount){
			EventBus.Post(new CharacterHealthModified(characterID, _currentHealth, amount));
		}
	}
}