using Script.Main.Character.Skill;
using Script.Main.InputData.Event;
using UnityEngine;

namespace Script.Main.Character{
	public class Character : MonoBehaviour{
		private CharacterMovement _movement;
		private CharacterSkill _skill;

		private string _baseSkillName;
		private string _strongSkillName;

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
			
			_skill.CreateSkill(_baseSkillName, new Skill.Skill("123", transform.position, transform.right));
		}

		private void OnStrongSkillDetected(StrongSkillDetected obj){
			_skill.CreateSkill(_strongSkillName, new Skill.Skill("123", transform.position, transform.right));

		}
	}
}