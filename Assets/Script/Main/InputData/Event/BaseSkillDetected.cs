using UnityEngine;

namespace Script.Main.InputData.Event{
	public class BaseSkillDetected{
		public string UserId{ get; }
		public Vector2 MouseWorldPosition{ get; }

		public BaseSkillDetected(string userId , Vector2 mouseWorldPosition){
			UserId = userId;
			MouseWorldPosition = mouseWorldPosition;
		}
	}
}