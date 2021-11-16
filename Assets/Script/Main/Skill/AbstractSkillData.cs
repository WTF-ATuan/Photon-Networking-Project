using UnityEngine;

namespace Script.Main.Skill{
	public abstract class AbstractSkillData : ScriptableObject , ISkillCast{
		public abstract void CastSkill(SkillSpawnInfo spawnInfo);
	}
}