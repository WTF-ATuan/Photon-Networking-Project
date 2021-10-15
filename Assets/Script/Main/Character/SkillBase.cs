using Script.Main.Character.Skill;
using UnityEngine;

namespace Script.Main.Character{
	[CreateAssetMenu(fileName = "Skill", menuName = "Skill", order = 0)]
	public class SkillBase : ScriptableObject{
		public string skillName;

		public float energyUsage;

		public AbstractSkill skill;

		public void InitSkill(SkillSpawnInfo spawnInfo){
			skill.InitSkill(spawnInfo);
		}
	}
}