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
			DetectAttackInput();
		}

		private void DetectMoveInput(){
			var horizontalValue = Input.GetAxisRaw($"Horizontal");
			var isJump = Input.GetKeyDown(KeyCode.Space);
			EventBus.Post(new MoveInputDetected(OwnerID, horizontalValue, isJump));
		}

		private void DetectAttackInput(){
			if(Input.GetMouseButtonDown(0)){
				EventBus.Post(new BaseSkillDetected(OwnerID));
			}
		}
	}
}