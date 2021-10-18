using Script.Main.Character.Skill.SkillEvent;
using UnityEngine;

namespace Script.Main.Character.Skill{
	public class CollisionDetector : MonoBehaviour{
		public string OwnerID{ get; private set; }

		public void InitDetector(string ownerID){
			OwnerID = ownerID;
		}

		private void OnCollisionEnter2D(Collision2D other){
			EventBus.Post(new SkillCollide(OwnerID, true, other));
		}

		private void OnCollisionExit2D(Collision2D other){
			EventBus.Post(new SkillCollide(OwnerID, false, other));
		}
	}
}