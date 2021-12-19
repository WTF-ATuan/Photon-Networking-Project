using UnityEngine;

namespace Script.Main.Character.Event{
	public class CharacterPositionUpdated{
		public string CharacterID{ get; }
		public Vector3 UpdatePosition{ get; }

		public CharacterPositionUpdated(string characterID , Vector3 updatePosition ){
			CharacterID = characterID;
			UpdatePosition = updatePosition;
		}
	}
}