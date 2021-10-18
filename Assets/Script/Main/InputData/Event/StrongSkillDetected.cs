using UnityEngine;

namespace Script.Main.InputData.Event{
	public class StrongSkillDetected{
		public string UserId{ get; }
		public Vector2 MouseWorldPosition{ get; }

		public StrongSkillDetected(string userId, Vector2 mouseWorldPosition){
			UserId = userId;
			MouseWorldPosition = mouseWorldPosition;
		}
	}
}