using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Main{
	public class CreateJoinRoom : MonoBehaviourPunCallbacks{
		[SerializeField] private InputField field1;
		[SerializeField] private InputField field2;

		public void CreateRoom(){
			PhotonNetwork.CreateRoom(field1.text);
		}

		public void JoinedRoom(){
			PhotonNetwork.JoinRoom(field2.text);
		}

		public override void OnJoinedRoom(){
			PhotonNetwork.LoadLevel("MainScene");
		}


	}
}