using Script.Main.Character.Event;
using UnityEngine;

namespace Script.Main{
	public class CharacterSpawner : MonoBehaviour{
		[SerializeField] private GameObject characterPre;
		[SerializeField] private Sever sever;

		private void Start(){
			var randomPosition = Random.insideUnitCircle * 3;
			var id = gameObject.GetInstanceID().ToString();
			sever.GenerateItem(characterPre.name, randomPosition, Quaternion.identity, id);
			EventBus.Subscribe<CharacterCreated>(OnCharacterCreated);
		}

		private void OnCharacterCreated(CharacterCreated obj){ }
	}
}