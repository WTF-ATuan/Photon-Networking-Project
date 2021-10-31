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
		}

		private void OnMoveInputDetected(MoveInputDetected obj){
			var userId = obj.UserId;
			var character = CharacterRepository.Query(userId);
			var horizontal = obj.Horizontal;
			var vertical = obj.Vertical;
			character.Move(horizontal, vertical);
			character.SetFaceDirection(horizontal);
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