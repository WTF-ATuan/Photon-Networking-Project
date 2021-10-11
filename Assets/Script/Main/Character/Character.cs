using Script.Main.InputData.Event;
using UnityEngine;

namespace Script.Main.Character{
	public class Character : MonoBehaviour{
		private CharacterMovement _movement;
		private CharacterSkill _skill;
		private void Start(){
			_movement = GetComponent<CharacterMovement>();
			_skill = GetComponent<CharacterSkill>();
			EventBus.Subscribe<MoveInputDetected>(OnMoveInputDetected);
			EventBus.Subscribe<BaseSkillDetected>(OnBaseSkillDetected);
			EventBus.Subscribe<StrongSkillDetected>(OnStrongSkillDetected);
		}

		private void OnMoveInputDetected(MoveInputDetected obj){
			var horizontal = obj.Horizontal;
			var vertical = obj.Vertical;
			_movement.Move(horizontal, vertical);
			_movement.SetFaceDirection(horizontal);
		}

		private void OnBaseSkillDetected(BaseSkillDetected obj){
			var userId = obj.UserId;
			_skill.CreateBaseSkill(userId);
		}

		private void OnStrongSkillDetected(StrongSkillDetected obj){ }
	}
}