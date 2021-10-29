using Script.Main.InputData.Event;

namespace Script.Main.Character{
	public class CharacterEventHandler{
		private CharacterRepository CharacterRepository{ get; }

		public CharacterEventHandler(){
			CharacterRepository = new CharacterRepository();
			EventBus.Subscribe<MoveInputDetected>(OnMoveInputDetected);
			EventBus.Subscribe<BaseSkillDetected>(OnBaseSkillDetected);
			EventBus.Subscribe<StrongSkillDetected>(OnStrongSkillDetected);
		}

		private void OnStrongSkillDetected(StrongSkillDetected obj){
			var userId = obj.UserId;
			var character = CharacterRepository.Query(userId);
		}

		private void OnBaseSkillDetected(BaseSkillDetected obj){
			var userId = obj.UserId;
			var character = CharacterRepository.Query(userId);
		}

		private void OnMoveInputDetected(MoveInputDetected obj){
			var userId = obj.UserId;
			var character = CharacterRepository.Query(userId);
		}
	}
}