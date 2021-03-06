using Script.Main.InputData.Event;
using UnityEngine;

namespace Script.Main.InputData{
	public class WasdInput : MonoBehaviour{
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
			var horizontalValue = HorizontalValue();
			var isJump = Input.GetKeyDown(KeyCode.W);
			EventBus.Post(new MoveInputDetected(OwnerID, horizontalValue, isJump));
		}

		private float HorizontalValue(){
			var left = Input.GetKey(KeyCode.A);
			var right = Input.GetKey(KeyCode.D);
			return left switch{
				false when !right => 0,
				true when !right => -1,
				false => 1,
				_ => 0
			};
		}

		private void DetectAttackInput(){
			if(Input.GetKeyDown(KeyCode.Space)){
				EventBus.Post(new BaseSkillDetected(OwnerID));
			}
		}
	}
}