using UnityEngine;

namespace Script.Main.InputData.Event{
	public class BaseSkillDetected{
		public string UserId{ get; }

		public BaseSkillDetected(string userId){
			UserId = userId;
		}
	}
}