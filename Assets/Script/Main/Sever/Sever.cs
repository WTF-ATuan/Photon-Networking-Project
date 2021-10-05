using Photon.Pun;
using UnityEngine;

namespace Script.Main{
	public class Sever : MonoBehaviour{
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
	}
}