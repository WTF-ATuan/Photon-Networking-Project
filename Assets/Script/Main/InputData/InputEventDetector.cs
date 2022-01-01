using Script.Main.InputData.Event;
using UnityEngine;

namespace Script.Main.InputData{
	public class InputEventDetector : MonoBehaviour{
		public string OwnerID{ get; private set; }

		public void Init(string ownerId){
			OwnerID = ownerId;
		}

		private void Update(){
			if(string.IsNullOrEmpty(OwnerID)){
				return;
			}

			DetectMoveInput();
			DetectBaseSkillInput();
		}

		private void DetectMoveInput(){
			var horizontalValue = Input.GetAxisRaw($"Horizontal");
			var verticalValue = Input.GetAxisRaw($"Vertical");
			var isJump = Input.GetKeyDown(KeyCode.Space);
			EventBus.Post(new MoveInputDetected(OwnerID, horizontalValue, verticalValue, isJump));
		}

		private void DetectBaseSkillInput(){
			if(Input.GetMouseButtonDown(0)){
				EventBus.Post(new BaseSkillDetected(OwnerID));
			}
		}
	}
}