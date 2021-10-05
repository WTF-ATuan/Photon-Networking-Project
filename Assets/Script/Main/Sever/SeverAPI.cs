using System;
using Photon.Pun;
using UnityEngine.SceneManagement;

namespace Script.Main{
	public class SeverAPI{
		public void LoadScene(string sceneName){
			var sceneCount = SceneManager.sceneCount;
			for(var i = 0; i < sceneCount; i++){
				var scene = SceneManager.GetSceneByBuildIndex(i);
				var containsName = scene.name == sceneName;
				if(containsName) break;
				throw new Exception($"#{sceneName}# is Not in build setting");
			}

			PhotonNetwork.LoadLevel(sceneName);
		}
	}
}