using System.Collections.Generic;
using UnityEngine;

namespace Script.Main.Character.Skill{
	public class CharacterSkill : MonoBehaviour{

		public List<AbstractSkill> skillList;
		public void CastSkill(string skillName, SkillSpawnInfo data){
			
		}

		public float GetSkillEnergyUsage(string skillName){
			return 0;
		}
	}
}