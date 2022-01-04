namespace Script.Main.InputData.Event{
	public class MoveInputDetected{
		public string UserId{ get; }
		public float Horizontal{ get; }
		public bool IsJump{ get; }

		public MoveInputDetected(string userId, float horizontal, bool isJump){
			UserId = userId;
			Horizontal = horizontal;
			IsJump = isJump;
		}
	}
}