using Script.Main.Character.Event;
using Script.Main.InputData;
using UnityEngine;

namespace Script.Main{
	public class CharacterSpawner : MonoBehaviour{
		[SerializeField] private GameObject characterPre;
		[SerializeField] private Sever sever;
		[SerializeField] private InputEventDetector inputEventDetector;
		

		private void Start(){
			var randomPosition = Random.insideUnitCircle * 3;
			var id = gameObject.GetInstanceID().ToString();
			var generateItem = sever.GenerateItem(characterPre.name, randomPosition, Quaternion.identity);
			EventBus.Post(new CharacterCreated(id));
			inputEventDetector.Init(id);
		}

	}
}