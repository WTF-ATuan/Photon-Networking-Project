using UnityEngine;

namespace Script.Main.Character.Event.ViewEvent{
	public class FaceDirectionFlipped{
		public string CharacterID{ get; }
		public Vector3 Rotation{ get; }

		public FaceDirectionFlipped(string characterID , Vector3 rotation ){
			CharacterID = characterID;
			Rotation = rotation;
		}
	}
}