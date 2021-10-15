using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Main.Character.Skill{
	public class CharacterSkill : MonoBehaviour{
		public List<AbstractSkill> skillList;

		public void CastSkill(string skillName, SkillSpawnInfo data){
			if(skillName == null){
				throw new Exception("Skill Name is Null");
			}

			var skill = skillList.Find(_ => _.SkillName() == skillName);
			if(skill == null){
				throw new Exception($"{skill} is not in List");
			}
			skill.InitSkill(data);
		}

		public float GetSkillEnergyUsage(string skillName){
			if(skillName == null){
				throw new Exception("Skill Name is Null");
			}

			var skill = skillList.Find(_ => _.SkillName() == skillName);
			if(skill == null){
				throw new Exception($"{skill} is not in List");
			}

			return skill.EnergyUsage();
		}
	}
}