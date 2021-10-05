using UnityEngine;

namespace Script.Main{
	public class Sever : MonoBehaviour{

		private SeverRequest _severRequest;

		private void Start(){
			_severRequest = new SeverRequest();
			_severRequest.ConnectSever();
			EventBus.Subscribe<SeverConnected>(OnSeverConnected);
		}

		private void OnSeverConnected(SeverConnected obj){
			_severRequest.JoinLobby();
		}
		
	}
}