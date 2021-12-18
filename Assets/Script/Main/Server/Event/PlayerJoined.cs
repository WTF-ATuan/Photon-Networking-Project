namespace Script.Main.Server.Event{
	public class PlayerJoined{
		public string PlayerID{ get; }
		public string SessionID{ get; }

		public PlayerJoined(string playerID , string sessionID){
			PlayerID = playerID;
			SessionID = sessionID;
		}
	}
}