using System;
using System.Linq;
using Photon.Bolt;
using Photon.Bolt.Matchmaking;
using Script.Main.Server.Event;
using UdpKit;
using UnityEngine;

namespace Script.Main.Server{
	public class ServerConnector : GlobalEventListener{
		private string _sessionID;
		private string _sceneName;

		private void Awake(){
			EventBus.Subscribe<SeverConnected>(OnSeverConnected);
			DontDestroyOnLoad(this);
		}

		private void OnSeverConnected(SeverConnected obj){
			var isSever = obj.IsSever;
			var sceneName = obj.SceneName;
			var sessionID = obj.SessionID;
			if(isSever){
				ConnectAsSever(sessionID, sceneName);
			}
			else{
				ConnectAsClient();
			}
		}

		private void ConnectAsSever(string sessionID, string sceneName){
			_sessionID = sessionID;
			_sceneName = sceneName;
			BoltLauncher.StartServer();
		}

		private void ConnectAsClient(){
			BoltLauncher.StartClient();
		}

		public override void BoltStartDone(){
			BoltMatchmaking.CreateSession(_sessionID, sceneToLoad: _sceneName);
			var playerID = Guid.NewGuid().ToString();
			EventBus.DynamicPost(new PlayerJoined(playerID, _sessionID));
		}

		public override void SessionListUpdated(Map<Guid, UdpSession> sessionList){
			foreach(var session in sessionList){
				var updSession = session.Value;
				if(updSession.Source == UdpSessionSource.Photon){
					BoltMatchmaking.JoinSession(updSession);
					var playerID = Guid.NewGuid().ToString();
					EventBus.DynamicPost(new PlayerJoined(playerID, _sessionID));
				}
			}
		}
	}
}