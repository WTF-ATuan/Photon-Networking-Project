using Script.Main.Character.Component;
using Script.Main.Character.Event;
using Script.Main.Character.Interface;
using Script.Main.InputData.Event;
using Script.Main.Server.Event;
using Script.Main.Utility;
using Sirenix.Utilities;

namespace Script.Main.Character{
	public class CharacterEventHandler{
		private CharacterRepository CharacterRepository{ get; }

		public CharacterEventHandler(){
			CharacterRepository = SingleRepository.Query<CharacterRepository>();
			EventBus.Subscribe<MoveInputDetected>(OnMoveInputDetected);
			EventBus.Subscribe<BaseSkillDetected>(OnBaseSkillDetected);
			EventBus.Subscribe<CharacterCreated>(OnCharacterCreated);
			EventBus.Subscribe<EntityAttached>(OnEntityAttached);
			EventBus.Subscribe<CharacterAnimated>(OnCharacterAnimated);
		}

		private void OnCharacterAnimated(CharacterAnimated obj){
			var characterID = obj.CharacterID;
			var animationName = obj.AnimationName;
			var timeScale = obj.AnimationTimeScale;
			var character = CharacterRepository.Query(characterID);
			character.PlayAnimation(animationName, timeScale);
		}

		private void OnCharacterCreated(CharacterCreated obj){
			var characterID = obj.CharacterID;
			var character = obj.Character;
			character.characterID = characterID;
			character.Initialize();
			CharacterRepository.Save(characterID, character);
		}

		private void OnEntityAttached(EntityAttached obj){
			var entityObject = obj.Entity;
			var entityID = obj.EntityID;
			var character = entityObject.GetComponent<Character>();
			if(character == null) return;
			var characterIdentities = entityObject.GetComponents<ICharacterIdentity>();
			characterIdentities.ForEach(x => x.SetCharacterID(entityID));
			character.characterID = entityID;
			if(CharacterRepository.ContainCharacter(entityID)){
				CharacterRepository.Save(entityID, character);
			}
		}

		private void OnMoveInputDetected(MoveInputDetected obj){
			var userId = obj.UserId;
			var character = CharacterRepository.Query(userId);
			var horizontal = obj.Horizontal;
			var isJump = obj.IsJump;
			character.Move(horizontal);
			character.SetFaceDirection(horizontal);
			if(isJump){
				character.Jump(horizontal);
			}
		}
		
		private void OnBaseSkillDetected(BaseSkillDetected obj){
			var userId = obj.UserId;
			var character = CharacterRepository.Query(userId);
			character.CastSkill(true);
		}
	}
}