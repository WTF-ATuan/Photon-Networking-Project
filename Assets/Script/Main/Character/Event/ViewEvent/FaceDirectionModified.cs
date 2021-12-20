using UnityEngine;

namespace Script.Main.Character.Event.ViewEvent{
	public class FaceDirectionModified{
		public string CharacterID{ get; }
		public Vector3 LocalScale{ get; }

		public FaceDirectionModified(string characterID , Vector3 localScale ){
			CharacterID = characterID;
			LocalScale = localScale;
		}
	}
}