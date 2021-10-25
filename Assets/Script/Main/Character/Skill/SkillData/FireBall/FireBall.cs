using UnityEngine;

namespace Script.Main.Character.Skill{
	public class FireBall : AbstractSkill{
		public override void InitSkill(SkillSpawnInfo spawnInfo){
			var direction = spawnInfo.Direction;
			var rigidbody = GetComponent<Rigidbody>();
			rigidbody.AddForce(direction * 500);
		}
	}
}