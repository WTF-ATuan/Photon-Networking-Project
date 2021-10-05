using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Main{
	public class CreateJoinRoom : MonoBehaviour{
		[SerializeField] private InputField field1;
		[SerializeField] private InputField field2;

		private void Start(){
			EventBus.Subscribe<RoomJoined>(OnJoinedRoom);
		}

		public void CreateRoom(){
			PhotonNetwork.CreateRoom(field1.text);
		}

		public void JoinedRoom(){
			PhotonNetwork.JoinRoom(field2.text);
		}

		private void OnJoinedRoom(RoomJoined obj){
			PhotonNetwork.LoadLevel("MainScene");
		}
	}
}