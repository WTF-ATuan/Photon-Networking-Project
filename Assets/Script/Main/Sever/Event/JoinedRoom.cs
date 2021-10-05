namespace Script.Main{
	public class JoinedRoom{
		public string UserId{ get; }
		public string RoomName{ get; }

		public JoinedRoom(string userId, string roomName){
			UserId = userId;
			RoomName = roomName;
		}
	}
}