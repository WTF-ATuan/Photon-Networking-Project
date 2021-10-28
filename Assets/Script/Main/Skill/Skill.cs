using System;
using System.Collections.Generic;
using Script.Main.Character;
using Script.Main.Character.Event;
using Script.Main.Skill.SkillEvent;
using UnityEngine;

namespace Script.Main.Skill{
	public class Skill : MonoBehaviour{
		public List<SkillCreatedTag> skillList;
		private void Start(){
			EventBus.Subscribe<SkillCollide>(OnSkillCollide);
			EventBus.Subscribe<SkillCasted>(OnSkillCasted);
		}

		private void OnSkillCasted(SkillCasted obj){
			var skillName = obj.SkillName;
			var data = obj.SpawnInfo;
			var skill = FindSkillCreatedTag(skillName);
			skill.InitSkill(data);
		}

		private void OnSkillCollide(SkillCollide obj){
			var collisionGameObject = obj.Collision.gameObject;
			var enemy = collisionGameObject.GetComponent<IModifyHp>();
			enemy?.ModifyHp(-10);
		}
		private SkillCreatedTag FindSkillCreatedTag(string skillName){
			if(skillName == null){
				throw new Exception("SkillName is Null");
			}

			var skill = skillList.Find(_ => _.name == skillName);
			if(skill == null){
				throw new Exception($"{skill} is not in List");
			}

			return skill;
		}
	}
}