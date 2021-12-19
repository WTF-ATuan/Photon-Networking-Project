using UnityEngine;

namespace Script.Main.Character.Event{
	public class CharacterMoved{
		public Vector2 OriginPosition{ get; }
		public Vector2 TargetPosition{ get; }

		public CharacterMoved(Vector2 originPosition , Vector2 targetPosition){
			OriginPosition = originPosition;
			TargetPosition = targetPosition;
		}
	}
}