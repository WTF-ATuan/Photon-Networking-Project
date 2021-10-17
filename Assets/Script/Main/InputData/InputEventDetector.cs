using Script.Main.InputData.Event;
using UnityEngine;

namespace Script.Main.InputData{
	public class InputEventDetector : MonoBehaviour{
		public string OwnerID{ get; private set; }

		public void Init(string ownerId){
			OwnerID = ownerId;
		}

		private void Update(){
			DetectMoveInput();
			DetectBaseSkillInput();
			DetectStrongSkillInput();
		}

		private void DetectMoveInput(){
			var horizontalValue = Input.GetAxisRaw($"Horizontal");
			var verticalValue = Input.GetAxisRaw($"Vertical");
			EventBus.Post(new MoveInputDetected(OwnerID, horizontalValue, verticalValue));
		}

		private void DetectBaseSkillInput(){
			if(Input.GetKeyDown(KeyCode.Q)){
				EventBus.Post(new BaseSkillDetected(OwnerID , MouseWorldPosition()));
			}
		}

		private void DetectStrongSkillInput(){
			if(Input.GetKeyDown(KeyCode.E)){
				EventBus.Post(new StrongSkillDetected(OwnerID , MouseWorldPosition()));
			}
		}

		private Vector2 MouseWorldPosition(){
			var worldPosition = Camera.main?.ScreenToWorldPoint(Input.mousePosition);
			return worldPosition ?? Vector2.zero;
		}
	}
}