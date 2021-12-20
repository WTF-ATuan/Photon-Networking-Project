using UnityEngine;

namespace Script.Main.Character.Event.ViewEvent{
	public class FaceDirectionFliped{
		public string CharacterID{ get; }
		public Vector3 LocalScale{ get; }

		public FaceDirectionFliped(string characterID , Vector3 localScale ){
			CharacterID = characterID;
			LocalScale = localScale;
		}
	}
}