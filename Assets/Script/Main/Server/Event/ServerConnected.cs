namespace Script.Main.Server.Event{
	public class ServerConnected{
		public bool IsSever{ get; }
		public string SessionID{ get; }
		public string SceneName{ get; }

		public ServerConnected(bool isSever, string sessionID, string sceneName){
			IsSever = isSever;
			SessionID = sessionID;
			SceneName = sceneName;
		}
	}
}