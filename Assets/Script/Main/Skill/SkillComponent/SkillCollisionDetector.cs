using System;
using Script.Main.Character.Skill.SkillEvent;
using UnityEngine;

namespace Script.Main.Skill{
	public class SkillCollisionDetector : MonoBehaviour{
		public string OwnerID{ get; private set; }
		public string SkillName{ get; private set; }

		public void InitDetector(string ownerID, string skillName){
			OwnerID = ownerID;
			SkillName = skillName;
		}

		private void OnCollisionEnter2D(Collision2D other){
			if(string.IsNullOrEmpty(OwnerID)){
				throw new NullReferenceException("OwnerID is Null or Empty Init First");
			}

			EventBus.Post(new SkillCollide(OwnerID, true, other));
		}

		private void OnCollisionExit2D(Collision2D other){
			if(string.IsNullOrEmpty(OwnerID)){
				throw new NullReferenceException("OwnerID is Null or Empty Init First");
			}

			EventBus.Post(new SkillCollide(OwnerID, false, other));
		}
	}
}