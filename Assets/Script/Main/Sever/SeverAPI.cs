using Photon.Pun;
using Script.Main.Event;
using UnityEngine;

namespace Script.Main{
	public class SeverAPI{
		public string CurrentSceneName{ get; private set; }

		public void LoadScene(string sceneName){
			CurrentSceneName = sceneName;
			PhotonNetwork.LoadLevel(sceneName);
		}

		public void GenerateItem(string dataName , Vector3 position , Quaternion rotation , string ownerId){
			var generateItem = PhotonNetwork.Instantiate(dataName, position, rotation);
			EventBus.Post(new ItemGenerated(ownerId , generateItem));
		}
	}
}