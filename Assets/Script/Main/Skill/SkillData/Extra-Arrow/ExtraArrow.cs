using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Script.Main.Skill.Extra_Arrow{
	public class ExtraArrow : AbstractSkillData{
		[SerializeField] private GameObject arrowViewObject = null;
		[SerializeField] private float intervalTime = 0.5f;
		[SerializeField] private int arrowCount = 2;

		private readonly List<GameObject> _skillObjectList = new List<GameObject>();

		public override async void CastSkill(SkillSpawnInfo spawnInfo){
			for(var i = 0; i < arrowCount; i++){
				await DelayInstantiate(intervalTime, spawnInfo);
			}
		}

		private async Task DelayInstantiate(float delayTime, SkillSpawnInfo spawnInfo){
			await Task.Delay((int)(delayTime * 1000));
			var originPosition = spawnInfo.OriginPosition;
			var skillObject = Instantiate(arrowViewObject, originPosition, Quaternion.identity);
			OnSkillObjectCreated(skillObject, spawnInfo);
			_skillObjectList.Add(skillObject);
		}

		private void OnSkillObjectCreated(GameObject skillObject, SkillSpawnInfo spawnInfo){
			var rigidbody2D = skillObject.GetComponent<Rigidbody2D>();
			var direction = spawnInfo.Direction;
			rigidbody2D.AddForce(direction * 10, ForceMode2D.Impulse);
		}
	}
}