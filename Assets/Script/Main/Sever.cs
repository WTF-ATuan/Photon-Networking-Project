using System;
using Photon.Pun;

namespace Script.Main{
	public class Sever : MonoBehaviourPunCallbacks{
		private void Start(){
			ConnectSever();
		}
		public void ConnectSever(){
			PhotonNetwork.ConnectUsingSettings();
		}

		public void JoinLobby(){
			PhotonNetwork.JoinLobby();
		}

		public void CreateRoom(string roomName){
			PhotonNetwork.CreateRoom(roomName);

		}

		public void JoinRoom(string roomName){
			PhotonNetwork.JoinRoom(roomName);
		}

		public override void OnConnectedToMaster(){
			var userId = PhotonNetwork.LocalPlayer.UserId;
			EventBus.Post(new SeverConnected(userId));
		}
	}
	public class SeverConnected{
		public string UserId{ get; }

		public SeverConnected(string userId){
			UserId = userId;
		}
	}
}