﻿using Photon.Pun;

namespace Script.Main{
	public class SeverCallbackPoster : MonoBehaviourPunCallbacks{
		public override void OnConnectedToMaster(){
			var userId = PhotonNetwork.LocalPlayer.UserId;
			EventBus.Post(new SeverConnected(userId));
		}

		public override void OnJoinedRoom(){
			var userId = PhotonNetwork.LocalPlayer.UserId;
			var roomName = PhotonNetwork.CurrentRoom.Name;
			EventBus.Post(new RoomJoined(userId, roomName));
		}

		public override void OnJoinedLobby(){
			var userId = PhotonNetwork.LocalPlayer.UserId;
			EventBus.Post(new LobbyJoined(userId));
		}
	}
}