using UnityEngine;

namespace Script.Main.InputData.Event{
	public class BaseSkillDetected{
		public string UserId{ get; }
		public Vector2 MousePosition{ get; }

		public BaseSkillDetected(string userId , Vector2 mousePosition){
			UserId = userId;
			MousePosition = mousePosition;
		}
	}
}