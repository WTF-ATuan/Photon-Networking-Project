using UnityEngine;

namespace Script.Main.Character.Event{
	public class CharacterJumped{
		public string CharacterID{ get; }
		public Vector2 Direction{ get; }
		public float Length{ get; }

		public CharacterJumped(string characterID , Vector2 direction, float length){
			CharacterID = characterID;
			Direction = direction;
			Length = length;
		}
	}
}