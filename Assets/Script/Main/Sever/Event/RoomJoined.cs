namespace Script.Main{
	public class RoomJoined{
		public string UserId{ get; }
		public string RoomName{ get; }

		public RoomJoined(string userId, string roomName){
			UserId = userId;
			RoomName = roomName;
		}
	}
}