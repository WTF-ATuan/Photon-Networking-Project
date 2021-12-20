﻿using Script.Main.Character.Event;
using Script.Main.InputData.Event;
using Script.Main.Server.Event;
using Script.Main.Utility;

namespace Script.Main.Character{
	public class CharacterEventHandler{
		private CharacterRepository CharacterRepository{ get; }

		public CharacterEventHandler(){
			CharacterRepository = SingleRepository.Query<CharacterRepository>();
			EventBus.Subscribe<MoveInputDetected>(OnMoveInputDetected);
			EventBus.Subscribe<BaseSkillDetected>(OnBaseSkillDetected);
			EventBus.Subscribe<StrongSkillDetected>(OnStrongSkillDetected);
			EventBus.Subscribe<CharacterCreated>(OnCharacterCreated);
			EventBus.Subscribe<EntityAttached>(OnEntityAttached);
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
			character.characterID = entityID;
			if(CharacterRepository.ContainCharacter(entityID)){
				CharacterRepository.Save(entityID, character);
			}
		}

		private void OnMoveInputDetected(MoveInputDetected obj){
			var userId = obj.UserId;
			var character = CharacterRepository.Query(userId);
			var horizontal = obj.Horizontal;
			var vertical = obj.Vertical;
			var isJump = obj.IsJump;
			character.Move(horizontal, vertical);
			character.SetFaceDirection(horizontal);
			if(isJump){
				character.Jump(horizontal);
			}
		}

		private void OnStrongSkillDetected(StrongSkillDetected obj){
			var userId = obj.UserId;
			var character = CharacterRepository.Query(userId);
			var direction = obj.MouseWorldPosition;
			character.CastSkill(direction, false);
		}

		private void OnBaseSkillDetected(BaseSkillDetected obj){
			var userId = obj.UserId;
			var character = CharacterRepository.Query(userId);
			var direction = obj.MouseWorldPosition;
			character.CastSkill(direction, true);
		}
	}
}