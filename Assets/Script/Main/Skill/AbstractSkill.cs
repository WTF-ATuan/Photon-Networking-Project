using Script.Main.Character.Skill;
using UnityEngine;

namespace Script.Main.Skill{
	public abstract class AbstractSkill : MonoBehaviour{
		public abstract void InitSkill(SkillSpawnInfo spawnInfo);
	}
}