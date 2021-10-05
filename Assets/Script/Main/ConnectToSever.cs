using UnityEngine;

namespace Script.Main{
	public class ConnectToSever : MonoBehaviour{

		public GameObject uiView;
		private void Start(){
			EventBus.Subscribe<LobbyJoined>(OnJoinedLobby);
		}

		private void OnJoinedLobby(LobbyJoined obj){
			uiView.SetActive(true);
		}
	}
}