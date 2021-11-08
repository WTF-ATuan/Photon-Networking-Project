using UnityEngine;

namespace Script.Main.Skill{
	[CreateAssetMenu(fileName = "Skill", menuName = "Skill", order = 0)]
	public class SkillCreatedTag : ScriptableObject{
		public float energyUsage;
		
		[SerializeField] private AbstractSkill skillComponent;

		public void CastSkill(SkillSpawnInfo spawnInfo){
			skillComponent.OnSkillCasted(spawnInfo);
		}
	}
}