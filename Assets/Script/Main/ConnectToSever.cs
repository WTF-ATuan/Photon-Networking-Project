using Photon.Pun;
using UnityEngine;

namespace Script.Main{
	public class ConnectToSever : MonoBehaviourPunCallbacks{

		public GameObject uiView;
		private void Start(){
			PhotonNetwork.ConnectUsingSettings();
		}

		public override void OnConnectedToMaster(){
			PhotonNetwork.JoinLobby();
		}

		public override void OnJoinedLobby(){
			uiView.SetActive(true);
		}
	}
}