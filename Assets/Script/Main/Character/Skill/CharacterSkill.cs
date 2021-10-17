using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Main.Character.Skill{
	public class CharacterSkill : MonoBehaviour{
		public List<SkillCreatedTag> skillList;

		public void CastSkill(string skillName, SkillSpawnInfo data){
			var skill = FindSkillCreatedTag(skillName);
			skill.InitSkill(data);
		}

		public float GetSkillEnergyUsage(string skillName){
			var skill = FindSkillCreatedTag(skillName);
			return skill.energyUsage;
		}

		private SkillCreatedTag FindSkillCreatedTag(string skillName){
			if(skillName == null){
				throw new Exception("SkillName is Null");
			}

			var skill = skillList.Find(_ => _.skillName == skillName);
			if(skill == null){
				throw new Exception($"{skill} is not in List");
			}

			return skill;
		}
	}
}