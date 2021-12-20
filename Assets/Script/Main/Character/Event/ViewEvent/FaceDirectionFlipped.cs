using UnityEngine;

namespace Script.Main.Character.Event.ViewEvent{
	public class FaceDirectionFlipped{
		public string CharacterID{ get; }
		public Vector3 LocalScale{ get; }

		public FaceDirectionFlipped(string characterID , Vector3 localScale ){
			CharacterID = characterID;
			LocalScale = localScale;
		}
	}
}