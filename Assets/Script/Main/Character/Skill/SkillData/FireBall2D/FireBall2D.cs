using UnityEngine;

namespace Script.Main.Character.Skill.SkillData.FireBall2D{
	public class FireBall2D : AbstractSkill{
		public override void InitSkill(SkillSpawnInfo spawnInfo){
			var direction = spawnInfo.Direction;
			var ownerID = spawnInfo.OwnerID;
			var rigidbody2D = GetComponent<Rigidbody2D>();
			var collisionDetector = GetComponent<SkillCollisionDetector>();
			collisionDetector.InitDetector(ownerID , GetType().Name);
			rigidbody2D.AddForce(direction * 500 , ForceMode2D.Impulse);
		}
	}
}