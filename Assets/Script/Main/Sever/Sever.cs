﻿using UnityEngine;

namespace Script.Main{
	public class Sever : MonoBehaviour{
		private SeverRequest _severRequest;
		private SeverAPI _severAPI;

		private void Start(){
			_severRequest = new SeverRequest();
			_severAPI = new SeverAPI();
			_severRequest.ConnectSever();
			EventBus.Subscribe<SeverConnected>(OnSeverConnected);
		}

		private void OnSeverConnected(SeverConnected obj){
			_severRequest.JoinLobby();
		}

		public void CreateRoom(string roomName){
			_severRequest.CreateRoom(roomName);
		}

		public void JoinRoom(string roomName){
			_severRequest.JoinRoom(roomName);
		}

		public void LoadScene(string sceneName){
			_severAPI.LoadScene(sceneName);
		}

		public void GenerateItem(string dataName, Vector3 position, Quaternion rotation, string ownerId){
			_severAPI.GenerateItem(dataName, position, rotation, ownerId);
		}
	}
}