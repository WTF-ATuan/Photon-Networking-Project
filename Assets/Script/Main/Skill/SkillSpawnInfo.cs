using UnityEngine;

namespace Script.Main.Skill{
	public class SkillSpawnInfo{
		public string OwnerID{ get; }
		public Vector3 OriginPosition{ get; }
		public Vector3 Direction{ get; }

		public SkillSpawnInfo(string ownerID, Vector3 originPosition, Vector3 direction){
			OwnerID = ownerID;
			OriginPosition = originPosition;
			Direction = direction;
		}
	}
}