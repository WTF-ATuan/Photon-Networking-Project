using System;
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
			EventBus.Subscribe<ServerConnected>(OnServerConnected);
			DontDestroyOnLoad(this);
		}

		private void OnServerConnected(ServerConnected obj){
			var isSever = obj.IsSever;
			var sceneName = obj.SceneName;
			var sessionID = obj.SessionID;
			if(isSever){
				ConnectAsServer(sessionID, sceneName);
			}
			else{
				ConnectAsClient();
			}
		}

		private void ConnectAsServer(string sessionID, string sceneName){
			_sessionID = sessionID;
			_sceneName = sceneName;
			BoltLauncher.StartServer();
		}
		private void ConnectAsClient(){
			BoltLauncher.StartClient();
		}

		public override void BoltStartDone(){
			if(!BoltNetwork.IsServer) return;
			BoltMatchmaking.CreateSession(_sessionID, sceneToLoad: _sceneName);
		}

		public override void EntityAttached(BoltEntity entity){
			var networkId = entity.NetworkId.ToString();
			var entityGameObject = entity.gameObject;
			EventBus.Post(new EntityAttached(networkId, entityGameObject));
		}

		public override void SessionListUpdated(Map<Guid, UdpSession> sessionList){
			foreach(var session in sessionList){
				var updSession = session.Value;
				if(updSession.Source == UdpSessionSource.Photon){
					BoltMatchmaking.JoinSession(updSession);
				}
			}
		}
		
		public override void SceneLoadLocalDone(string scene, IProtocolToken token){
			Debug.Log($"Local");
		}

		public override void SceneLoadRemoteDone(BoltConnection connection, IProtocolToken token){
			Debug.Log($"Remote");
		}
	}
}