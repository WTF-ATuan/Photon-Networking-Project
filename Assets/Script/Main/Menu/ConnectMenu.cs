using Script.Main.Server.Event;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Main.Menu{
	public class ConnectMenu : MonoBehaviour{
		[SerializeField] private InputField sessionID;
		[SerializeField] private SceneObject scene;


		public void ConnectSever(){
			EventBus.Post(new SeverConnected(true, sessionID.text, scene.ToString()));
		}

		public void ConnectClient(){
			EventBus.Post(new SeverConnected(false, sessionID.text, scene.ToString()));
		}
	}
}