using Photon.Bolt;
using Script.Main.Character.Event;
using Script.Main.InputData;
using UnityEngine;

namespace Script.Main{
	public class CharacterSpawner : MonoBehaviour{
		[SerializeField] private GameObject characterPre;


		private void Start(){
			var randomPosition = Random.insideUnitCircle * 3;
			var isRunning = BoltNetwork.IsRunning;
			if(isRunning){
				var entity = BoltNetwork.Instantiate(characterPre, randomPosition, Quaternion.identity);
				var character = entity.GetComponent<Character.Character>();
				var id = entity.NetworkId.ToString();
				character.gameObject.AddComponent<InputEventDetector>().Init(id);
				EventBus.Post(new CharacterCreated(id, character));
			}
			else{
				var entity = Instantiate(characterPre, randomPosition, Quaternion.identity);
				var character = entity.GetComponent<Character.Character>();
				var id = entity.GetInstanceID().ToString();
				character.gameObject.AddComponent<InputEventDetector>().Init(id);
				EventBus.Post(new CharacterCreated(id, character));
			}
		}
	}
}