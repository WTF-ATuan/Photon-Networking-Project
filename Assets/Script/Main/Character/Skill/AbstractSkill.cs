using UnityEngine;

namespace Script.Main.Character.Skill{
	public abstract class AbstractSkill : MonoBehaviour{
		public abstract void InitSkill(SkillSpawnInfo spawnInfo);
	}
}