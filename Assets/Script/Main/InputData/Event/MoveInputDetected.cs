namespace Script.Main.InputData.Event{
	public class MoveInputDetected{
		public string UserId{ get; }
		public float Horizontal{ get; }
		public float Vertical{ get; }
		public bool IsTumbleRoll{ get; }

		public MoveInputDetected(string userId, float horizontal, float vertical, bool isTumbleRoll){
			UserId = userId;
			Horizontal = horizontal;
			Vertical = vertical;
			IsTumbleRoll = isTumbleRoll;
		}
	}
}