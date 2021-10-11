using Script.Main.InputData.Event;
using UnityEngine;

namespace Script.Main.InputData{
	public class InputEventDetector : MonoBehaviour{
		private void Update(){
			DetectMoveInput();
			DetectBaseSkillInput();
			DetectStrongSkillInput();
		}

		private void DetectMoveInput(){
			var horizontalValue = Input.GetAxisRaw($"Horizontal");
			var verticalValue = Input.GetAxisRaw($"Vertical");
			EventBus.Post(new MoveInputDetected("123" , horizontalValue , verticalValue));
		}

		private void DetectBaseSkillInput(){
			if(Input.GetKeyDown(KeyCode.Q)){
				EventBus.Post(new BaseSkillDetected("123"));
			}
		}
		private void DetectStrongSkillInput(){
			if(Input.GetKeyDown(KeyCode.E)){
				EventBus.Post(new StrongSkillDetected("123"));
			}
		}


	}
}