using UnityEngine;

namespace Script.Main.Character.Event.ViewEvent{
	public class PositionUpdated{
		public string CharacterID{ get; }
		public Vector3 UpdatePosition{ get; }

		public PositionUpdated(string characterID , Vector3 updatePosition ){
			CharacterID = characterID;
			UpdatePosition = updatePosition;
		}
	}
}