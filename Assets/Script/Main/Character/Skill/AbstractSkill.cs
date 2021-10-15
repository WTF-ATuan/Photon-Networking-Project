using UnityEngine;

namespace Script.Main.Character.Skill{
	public abstract class AbstractSkill : MonoBehaviour{
		public abstract string SkillName();
		public abstract void InitSkill(SkillSpawnInfo spawnInfo);
		public abstract float EnergyUsage();
	}
}