using Script.Main.Skill;
using UnityEngine;

namespace Script.Main.Character.Skill{
	public class FireBall : AbstractSkill{
		public override void OnSkillCasted(SkillSpawnInfo spawnInfo){
			var originPosition = spawnInfo.OriginPosition;
			var direction = spawnInfo.Direction;
			var skillObject = Instantiate(this, originPosition, Quaternion.identity);
			var rigidBody = skillObject.GetComponent<Rigidbody>();
			rigidBody.AddForce(direction * 10);
		}
	}
}