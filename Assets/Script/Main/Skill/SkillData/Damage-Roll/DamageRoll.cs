using Script.Main.Character;
using Script.Main.Character.Event;
using UnityEngine;

namespace Script.Main.Skill.Damage_Roll{
	public class DamageRoll : AbstractSkill{
		public override void OnSkillCasted(SkillSpawnInfo spawnInfo){
			var direction = spawnInfo.Direction;
			var characterID = spawnInfo.OwnerID;
			var originPosition = spawnInfo.OriginPosition;
			EventBus.Post(new CharacterRolled(characterID, direction, 2));
			var raycastAll = Physics2D.RaycastAll(originPosition , direction , 2f);
			foreach(var raycastHit in raycastAll){
				var hitCollider = raycastHit.collider;
				var modifyHp = hitCollider.GetComponent<IModifyHp>();
				modifyHp.ModifyHp(-10);
			}
		}
	}
}