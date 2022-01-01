using UnityEngine;

namespace Script.Main.Character.Event{
	public class CharacterChosen{
		public GameObject CharacterPrefab{ get; }
		public int IndexOfPlayer{ get; }

		public CharacterChosen(GameObject characterPrefab, int indexOfPlayer){
			CharacterPrefab = characterPrefab;
			IndexOfPlayer = indexOfPlayer;
		}
	}
}