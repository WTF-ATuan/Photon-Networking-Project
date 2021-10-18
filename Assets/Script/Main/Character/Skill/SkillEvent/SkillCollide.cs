using UnityEngine;

namespace Script.Main.Character.Skill.SkillEvent{
	public class SkillCollide{
		public string OwnerID{ get; }
		public bool IsEnter{ get; }
		public Collision2D Collision{ get; }

		public SkillCollide(string ownerID, bool isEnter, Collision2D collision){
			OwnerID = ownerID;
			IsEnter = isEnter;
			Collision = collision;
		}
	}
}