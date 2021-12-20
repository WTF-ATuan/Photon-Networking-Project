using Photon.Bolt;
using Script.Main.Character.Event;
using Script.Main.InputData;
using UnityEngine;

namespace Script.Main{
	public class CharacterSpawner : MonoBehaviour{
		[SerializeField] private GameObject characterPre;
		[SerializeField] private InputEventDetector inputEventDetector;


		private void Start(){
			var randomPosition = Random.insideUnitCircle * 3;
			var id = characterPre.GetComponent<BoltEntity>().NetworkId.ToString();
			var generateItem = BoltNetwork.Instantiate(characterPre, randomPosition, Quaternion.identity);
			var character = generateItem.GetComponent<Character.Character>();
			EventBus.Post(new CharacterCreated(id, character));
			inputEventDetector.Init(id);
		}
	}
}