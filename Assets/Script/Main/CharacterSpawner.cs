using Photon.Bolt;
using Script.Main.Character.Event;
using Script.Main.InputData;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Script.Main{
	public class CharacterSpawner : MonoBehaviour{
		private void Start(){
			EventBus.ExecutePostBuffer<CharacterChosen>(OnCharacterChosen);
		}

		private void OnCharacterChosen(CharacterChosen obj){
			var characterPrefab = obj.CharacterPrefab;
			var randomPosition = Random.insideUnitCircle * 3;
			var isRunning = BoltNetwork.IsRunning;
			if(isRunning){
				CreateCharacterOnServer(characterPrefab, randomPosition);
			}
			else{
				CreateCharacterOnLocal(characterPrefab, 0, randomPosition);
			}
		}

		public void CreateCharacterOnServer(GameObject characterPrefab, Vector3 spawnPosition){
			var entity = BoltNetwork.Instantiate(characterPrefab, spawnPosition, Quaternion.identity);
			var character = entity.GetComponent<Character.Character>();
			var id = entity.NetworkId.ToString();
			character.gameObject.AddComponent<InputEventDetector>().Init(id);
			EventBus.Post(new CharacterCreated(id, character));
		}

		[Button]
		public void CreateCharacterOnLocal(GameObject characterPrefab, int playerIndex, Vector3 spawnPosition){
			var entity = Instantiate(characterPrefab, spawnPosition, Quaternion.identity);
			var character = entity.GetComponent<Character.Character>();
			var id = entity.GetInstanceID().ToString();
			Debug.Log($"playerIndex = {playerIndex}");
			switch(playerIndex){
				case 0:
					character.gameObject.AddComponent<WasdInput>().Init(id);
					break;
				case 1:
					character.gameObject.AddComponent<ArrowInput>().Init(id);
					break;
			}

			EventBus.Post(new CharacterCreated(id, character));
		}
	}
}