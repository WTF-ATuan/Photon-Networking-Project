using Script.Main.Character.Event;
using Script.Main.InputData;
using Script.Main.Skill;
using Script.Main.Utility;
using UnityEngine;

namespace Script.Main.Character{
	public class Character : MonoBehaviour{
		public string characterID = "123";

		private CharacterMovement _movement;
		private string _baseSkillName = "FireBall";
		private string _strongSkillName = "FireBall2D";

		private void Start(){
			_movement = GetComponent<CharacterMovement>();
		}

		public void Move(float horizontal, float vertical){
			_movement?.Move(horizontal, vertical);
		}

		public void SetFaceDirection(float direction){
			if(direction != 0){
				_movement.SetFaceDirection(direction);
			}
		}

		public void CastSkill(Vector2 direction, bool isBase){
			if(isBase){
				EventBus.Post(new SkillCasted(_baseSkillName,
					new SkillSpawnInfo(characterID, transform.position, direction)));
			}
			else{
				EventBus.Post(new SkillCasted(_strongSkillName,
					new SkillSpawnInfo(characterID, transform.position, direction)));
			}
		}
	}
}