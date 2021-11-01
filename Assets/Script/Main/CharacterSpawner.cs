using Script.Main.Character.Event;
using UnityEngine;

namespace Script.Main{
	public class CharacterSpawner : MonoBehaviour{
		[SerializeField] private GameObject characterPre;

		private void Start(){
			EventBus.Subscribe<CharacterCreated>(OnCharacterCreated);
		}

		private void OnCharacterCreated(CharacterCreated obj){
						
		}
	}
}