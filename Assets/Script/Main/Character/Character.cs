using Script.Main.Character.Event;
using Script.Main.InputData;
using Script.Main.Skill;
using Script.Main.Utility;
using UnityEngine;

namespace Script.Main.Character{
	public class Character : MonoBehaviour{
		public string characterID = "123";

		private CharacterMovement _movement;
		private CharacterRepository _repository;
		private CharacterEventHandler _eventHandler;
		private InputEventDetector _inputEventDetector;

		private string _baseSkillName = "FireBall";
		private string _strongSkillName = "FireBall2D";

		private void Start(){
			_movement = GetComponent<CharacterMovement>();
			_inputEventDetector = GetComponent<InputEventDetector>();
			_repository = SingleRepository.QueryObject<CharacterRepository>();
			_eventHandler = SingleRepository.QueryObject<CharacterEventHandler>();
			_repository.Save(characterID, this);
			_inputEventDetector.Init(characterID);
		}

		public void Move(float horizontal, float vertical){
			_movement.Move(horizontal, vertical);
		}

		public void SetFaceDirection(float direction){
			if(direction != 0){
				_movement.SetFaceDirection(direction);
			}
		}

		public void CastSkill(Vector2 direction, bool isBase){
			if(isBase){
				EventBus.Post(new SkillCasted(_baseSkillName,
					new SkillSpawnInfo("123", transform.position, direction)));
			}
			else{
				EventBus.Post(new SkillCasted(_strongSkillName,
					new SkillSpawnInfo("123", transform.position, direction)));
			}
		}
	}
}