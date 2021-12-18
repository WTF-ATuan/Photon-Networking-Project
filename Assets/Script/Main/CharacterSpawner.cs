using Photon.Bolt;
using Script.Main.Character.Event;
using Script.Main.InputData;
using Script.Main.Server.Event;
using UnityEngine;

namespace Script.Main{
	public class CharacterSpawner : MonoBehaviour{
		[SerializeField] private GameObject characterPre;
		[SerializeField] private InputEventDetector inputEventDetector;


		private void Awake(){
			EventBus.InvokePostBuffer<PlayerJoined>(OnPlayerJoined);
		}

		private void OnPlayerJoined(PlayerJoined obj){
			var randomPosition = Random.insideUnitCircle * 3;
			var id = obj.PlayerID;
			var generateItem = BoltNetwork.Instantiate(characterPre, randomPosition, Quaternion.identity);
			var character = generateItem.GetComponent<Character.Character>();
			EventBus.Post(new CharacterCreated(id, character));
			inputEventDetector.Init(id);
		}
	}
}