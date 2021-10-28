using Script.Main.Character.Skill;
using UnityEngine;

namespace Script.Main.Skill{
	[CreateAssetMenu(fileName = "Skill", menuName = "Skill", order = 0)]
	public class SkillCreatedTag : ScriptableObject{
		public string skillName;

		public float energyUsage;
		
		public AbstractSkill abstractSkill;

		public void InitSkill(SkillSpawnInfo spawnInfo){
			var originPosition = spawnInfo.OriginPosition;
			var skill = Instantiate(abstractSkill , originPosition , Quaternion.identity );
			skill.InitSkill(spawnInfo);
		}
	}
}