using Script.Main.Character;
using Script.Main.Skill.SkillEvent;
using UnityEngine;

namespace Script.Main.Skill{
	public class Skill : MonoBehaviour{
		private void Start(){
			EventBus.Subscribe<SkillCollide>(OnSkillCollide);
		}

		private void OnSkillCollide(SkillCollide obj){
			var collisionGameObject = obj.Collision.gameObject;
			var enemy = collisionGameObject.GetComponent<IModifyHp>();
			enemy?.ModifyHp(-10);
		}
	}
}