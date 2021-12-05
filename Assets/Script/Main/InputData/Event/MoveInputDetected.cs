﻿namespace Script.Main.InputData.Event{
	public class MoveInputDetected{
		public string UserId{ get; }
		public float Horizontal{ get; }
		public float Vertical{ get; }
		public bool IsJump{ get; }

		public MoveInputDetected(string userId, float horizontal, float vertical, bool isJump){
			UserId = userId;
			Horizontal = horizontal;
			Vertical = vertical;
			IsJump = isJump;
		}
	}
}