using Script.Main.InputData.Event;
using UnityEngine;

namespace Script.Main.InputData{
	public class InputAdapter : MonoBehaviour{
		private void Update(){
			DetectMoveInput();
		}

		private void DetectMoveInput(){
			var horizontalValue = Input.GetAxisRaw($"Horizontal");
			var verticalValue = Input.GetAxisRaw($"Vertical");
			if(horizontalValue != 0 || verticalValue != 0){
				EventBus.Post(new MoveInputDetected("123" , horizontalValue , verticalValue));
			}

		}
		
	}
}