using Photon.Pun;
using UnityEngine;

namespace Script.Main{
	public class GUIMessage : MonoBehaviour{
		private void OnGUI(){
			int width = Screen.width, height = Screen.height;
			var style = new GUIStyle();
			var rect = new Rect(0, 0, width, height * 2 / 100);
			style.alignment = TextAnchor.UpperLeft;
			style.fontSize = height * 3 / 100;
			style.fontStyle = FontStyle.Bold;
			style.normal.textColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);

			var localUserId = PhotonNetwork.LocalPlayer.UserId;
			var localUserIndex = PhotonNetwork.LocalPlayer.ActorNumber;
			var currentRoomName = PhotonNetwork.CurrentRoom.Name;
			var currentLobbyName = PhotonNetwork.CurrentLobby.Name;
			var guiText = "Lobby" + currentLobbyName + "\r\n" +
						  "Room : " + currentRoomName + "\r\n" +
						  "User ID : " + localUserId + "\r\n" +
						  "User Index : " + localUserIndex + "\r\n";
			GUI.Label(rect, guiText, style);
		}
	}
}