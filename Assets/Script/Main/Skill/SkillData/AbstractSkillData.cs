using UnityEngine;

namespace Script.Main.Skill{
	public abstract class AbstractSkillData : ScriptableObject, ISkillCastData{
		public string SkillName => name;
		public abstract void CastSkill(SkillSpawnInfo spawnInfo);
	}
}