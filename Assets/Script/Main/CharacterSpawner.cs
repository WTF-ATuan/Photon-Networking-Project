using Photon.Bolt;
using Script.Main.Character.Event;
using Script.Main.InputData;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Script.Main{
	public class CharacterSpawner : MonoBehaviour{
		[SerializeField] private GameObject characterPre;


		private void Start(){
			var randomPosition = Random.insideUnitCircle * 3;
			var isRunning = BoltNetwork.IsRunning;
			if(isRunning){
				CreateCharacterOnServer(randomPosition);
			}
			else{
				CreateCharacterOnLocal(0, randomPosition);
			}
		}

		public void CreateCharacterOnServer(Vector3 spawnPosition){
			var entity = BoltNetwork.Instantiate(characterPre, spawnPosition, Quaternion.identity);
			var character = entity.GetComponent<Character.Character>();
			var id = entity.NetworkId.ToString();
			character.gameObject.AddComponent<InputEventDetector>().Init(id);
			EventBus.Post(new CharacterCreated(id, character));
		}
		[Button]
		public void CreateCharacterOnLocal(int playerIndex, Vector3 spawnPosition){
			var entity = Instantiate(characterPre, spawnPosition, Quaternion.identity);
			var character = entity.GetComponent<Character.Character>();
			var id = entity.GetInstanceID().ToString();
			if(playerIndex == 0){
				character.gameObject.AddComponent<WasdInput>().Init(id);
			}
			else{
				character.gameObject.AddComponent<ArrowInput>().Init(id);
			}

			EventBus.Post(new CharacterCreated(id, character));
		}
	}
}