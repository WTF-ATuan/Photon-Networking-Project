using Script.Main.Character.Event;

namespace Script.Main.Skill.Damage_Roll{
	public class DamageRoll : AbstractSkill{
		public override void OnSkillCasted(SkillSpawnInfo spawnInfo){
			var direction = spawnInfo.Direction;
			var characterID = spawnInfo.OwnerID;
			var originPosition = spawnInfo.OriginPosition;
			EventBus.Post(new CharacterRolled(characterID, direction, 2));
		}
	}
}