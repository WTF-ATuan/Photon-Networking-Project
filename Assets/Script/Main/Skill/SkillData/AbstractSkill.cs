using UnityEngine;

namespace Script.Main.Skill{
	public abstract class AbstractSkill : MonoBehaviour{
		public abstract void OnSkillCasted(SkillSpawnInfo spawnInfo);
		public virtual void OnSkillCreated(SkillSpawnInfo spawnInfo){ }
	}
}