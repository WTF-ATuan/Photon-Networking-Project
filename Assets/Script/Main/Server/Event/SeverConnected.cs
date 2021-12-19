namespace Script.Main.Server.Event{
	public class SeverConnected{
		public bool IsSever{ get; }
		public string SessionID{ get; }
		public string SceneName{ get; }

		public SeverConnected(bool isSever, string sessionID, string sceneName){
			IsSever = isSever;
			SessionID = sessionID;
			SceneName = sceneName;
		}
	}
}