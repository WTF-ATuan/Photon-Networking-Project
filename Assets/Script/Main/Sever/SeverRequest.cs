using Photon.Pun;

namespace Script.Main{
	public class SeverRequest{
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