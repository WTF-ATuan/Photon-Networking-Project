﻿using Script.Main.Character.Event;
using Script.Main.InputData.Event;
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
			EventBus.Subscribe<CharacterJumped>(OnCharacterJumped);
		}

		private void OnCharacterJumped(CharacterJumped obj){
			var characterID = obj.CharacterID;
			var direction = obj.Direction;
			var character = CharacterRepository.Query(characterID);
			character.Jump(direction.x);
		}

		private void OnCharacterCreated(CharacterCreated obj){
			var characterID = obj.CharacterID;
			var character = obj.Character;
			character.characterID = characterID;
			CharacterRepository.Save(characterID, character);
		}

		private void OnMoveInputDetected(MoveInputDetected obj){
			var userId = obj.UserId;
			var character = CharacterRepository.Query(userId);
			var horizontal = obj.Horizontal;
			var vertical = obj.Vertical;
			var isTumbleRoll = obj.IsTumbleRoll;
			character.Move(horizontal, vertical);
			character.SetFaceDirection(horizontal);
			if(isTumbleRoll){
				character.TumbleRoll(horizontal, vertical);
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