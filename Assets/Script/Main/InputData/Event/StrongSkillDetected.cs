namespace Script.Main.InputData.Event{
	public class StrongSkillDetected{
		public string UserId{ get; }

		public StrongSkillDetected(string userId){
			UserId = userId;
		}
	}
}