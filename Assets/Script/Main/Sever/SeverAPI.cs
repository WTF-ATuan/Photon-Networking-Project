using Photon.Pun;
using UnityEngine;

namespace Script.Main{
	public class SeverAPI{
		public string CurrentSceneName{ get; private set; }

		public void LoadScene(string sceneName){
			CurrentSceneName = sceneName;
			PhotonNetwork.LoadLevel(sceneName);
		}

		public GameObject GenerateItem(string dataName , Vector3 position , Quaternion rotation){
			var generateItem = PhotonNetwork.Instantiate(dataName, position, rotation);
			return generateItem;
		}
	}
}