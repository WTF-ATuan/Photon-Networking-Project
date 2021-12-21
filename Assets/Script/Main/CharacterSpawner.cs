using Photon.Bolt;
using Script.Main.Character.Event;
using Script.Main.InputData;
using UnityEngine;

namespace Script.Main{
	public class CharacterSpawner : MonoBehaviour{
		[SerializeField] private GameObject characterPre;


		private void Start(){
			Debug.Log($"123 = {123}");
			var randomPosition = Random.insideUnitCircle * 3;
			var entity = BoltNetwork.Instantiate(characterPre, randomPosition, Quaternion.identity);
			var character = entity.GetComponent<Character.Character>();
			var id = entity.NetworkId.ToString();
			character.gameObject.AddComponent<InputEventDetector>().Init(id);
			EventBus.Post(new CharacterCreated(id, character));
		}
	}
}