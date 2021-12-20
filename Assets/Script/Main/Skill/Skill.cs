using System;
using System.Collections.Generic;
using System.Linq;
using Script.Main.Character.Event;
using UnityEngine;

namespace Script.Main.Skill{
	public class Skill : MonoBehaviour{
		[SerializeField] private List<AbstractSkillData> skillList;

		private List<ISkillCastData> SkillCastData => skillList.Cast<ISkillCastData>().ToList();

		private void Start(){
			EventBus.Subscribe<SkillCasted>(OnSkillCasted);
		}

		private void OnSkillCasted(SkillCasted obj){
			var skillName = obj.SkillName;
			var data = obj.SpawnInfo;
			var skill = FindSkillCastData(skillName);
			skill.CastSkill(data);
		}


		private ISkillCastData FindSkillCastData(string skillName){
			if(string.IsNullOrEmpty(skillName)){
				throw new Exception("SkillName is Null");
			}

			var castData = SkillCastData.Find(x => x.SkillName == skillName);
			if(castData == null){
				throw new Exception($"{skillName} is not in List");
			}

			return castData;
		}
	}
}