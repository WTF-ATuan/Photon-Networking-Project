using Script.Main.Server.Event;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Main.Menu{
	public class ConnectMenu : MonoBehaviour{
		[SerializeField] private InputField sessionID;
		[SerializeField] private SceneObject scene;


		public void ConnectServer(){
			EventBus.Post(new ServerConnected(true, sessionID.text, scene.ToString()));
		}

		public void ConnectClient(){
			EventBus.Post(new ServerConnected(false, sessionID.text, scene.ToString()));
		}
	}
}