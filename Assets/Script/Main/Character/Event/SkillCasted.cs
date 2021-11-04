using Script.Main.Skill;
using UnityEngine;

namespace Script.Main.Character.Event{
	public class SkillCasted{
		public string SkillName{ get; }
		public SkillSpawnInfo SpawnInfo{ get; }

		public SkillCasted(string skillName, SkillSpawnInfo spawnInfo){
			SkillName = skillName;
			SpawnInfo = spawnInfo;
		}
	}
}