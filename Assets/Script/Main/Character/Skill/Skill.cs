using UnityEngine;

namespace Script.Main.Character.Skill{
	public class Skill{
		public string OwnerID{ get; }
		public Vector3 OriginPosition{ get; }
		public Vector3 Direction{ get; }

		public Skill(string ownerID, Vector3 originPosition, Vector3 direction){
			OwnerID = ownerID;
			OriginPosition = originPosition;
			Direction = direction;
		}
	}
}