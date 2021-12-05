using UnityEngine;

namespace Script.Main.Character.Event{
	public class CharacterRolled{
		public string CharacterID{ get; }
		public Vector2 Direction{ get; }
		public float Length{ get; }

		public CharacterRolled(string characterID , Vector2 direction, float length){
			CharacterID = characterID;
			Direction = direction;
			Length = length;
		}
	}
}