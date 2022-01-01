using Script.Main.Character.Event;
using Script.Main.Character.Event.ViewEvent;
using Script.Main.Character.Interface;
using Sirenix.OdinInspector;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Main.Character{
	public class Character : MonoBehaviour{
		[ReadOnly] public string characterID = "BIG_BOSS";
		[SerializeField] private int defaultHealth = 100;
		private int _currentHealth;

		private ICharacterAbility _characterAbility;
		private IGround _groundCheck;
		private IJump _jump;
		private IAttack _attack;

		private Rigidbody2D _rigidbody2D;

		private SkeletonAnimation _animation;

		//FOR TEST
		private Image _hpBar;

		public void Initialize(){
			_rigidbody2D = GetComponent<Rigidbody2D>();
			_animation = GetComponent<SkeletonAnimation>();
			_hpBar = GetComponentInChildren<Image>();
			_characterAbility = GetComponent<ICharacterAbility>();
			_groundCheck = GetComponent<IGround>();
			_jump = GetComponent<IJump>();
			_attack = GetComponent<IAttack>();
			_currentHealth = defaultHealth;
		}

		public void Move(float horizontal){
			var speed = _characterAbility.QueryAbility(CharacterAbilityType.MoveSpeed);
			var acceleration = horizontal * speed;
			var currentVelocity = _rigidbody2D.velocity;
			var nextVelocity = new Vector2(acceleration, currentVelocity.y);
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

		public void CastSkill(bool isBase){
			var direction = GetFacingDirection();
			var canAttack = _attack.CanAttack();
			if(canAttack){
				_attack.Attack(direction);
			}
		}

		private Vector3 GetFacingDirection(){
			var leftRotation = new Vector3(0, 180, 0);
			var characterRotation = transform.eulerAngles;
			var isLeft = characterRotation == leftRotation;
			var direction = isLeft ? Vector2.left : Vector2.right;
			return direction;
		}

		[Button]
		public void PlayAnimation(string animationName, float animationTimeScale){
			if(animationName == "idle" || animationName == "Run"){
				var currentAnimationName = _animation.AnimationName;
				if(currentAnimationName == "idle" || currentAnimationName == "Run"){
					_animation.AnimationName = animationName;
				}
				var entry = _animation.state.GetCurrent(0);
				if(!entry.IsComplete) return;
			}

			_animation.AnimationName = animationName;
			_animation.timeScale = animationTimeScale;
		}


		public void ModifyHp(int amount){
			_currentHealth += amount;
			EventBus.Post(new CharacterHealthModified(characterID, _currentHealth, amount));
			var hpBarRect = _hpBar.GetComponent<RectTransform>();
			var height = hpBarRect.sizeDelta.y;
			hpBarRect.sizeDelta = new Vector2(_currentHealth - amount, height);
			if(_currentHealth <= 0){
				Die();
			}
		}

		//TODO
		public void Die(){
			gameObject.SetActive(false);
		}
	}
}