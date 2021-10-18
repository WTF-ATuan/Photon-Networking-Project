using UnityEngine;

namespace Script.Main.Character.Skill.SkillData.FireBall2D{
	public class FireBall2D : AbstractSkill{
		public override void InitSkill(SkillSpawnInfo spawnInfo){
			var direction = spawnInfo.Direction;
			var rigidbody2D = GetComponent<Rigidbody2D>();
			rigidbody2D.AddForce(direction * 50);
		}
	}
}