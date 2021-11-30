using System.Threading.Tasks;
using Script.Main.Enemy.Interface;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Script.Main.Skill.SkillData.FireBall2D{
	public class FireBall2D : AbstractSkillData{
		[SerializeField] private GameObject fireballViewObject;

		public override void CastSkill(SkillSpawnInfo spawnInfo){
			var originPosition = spawnInfo.OriginPosition;
			var skillObject = Instantiate(fireballViewObject, originPosition, Quaternion.identity);
			skillObject.OnCollisionEnter2DAsObservable()
					.Subscribe(x => OnSkillObjectCollisionEnter(skillObject))
					.AddTo(skillObject);
			OnSkillObjectCreated(skillObject, spawnInfo);
		}

		private void OnSkillObjectCreated(GameObject skillObject, SkillSpawnInfo spawnInfo){
			var direction = spawnInfo.Direction;
			var rigidbody2D = skillObject.GetComponent<Rigidbody2D>();
			rigidbody2D.AddForce(direction * 10, ForceMode2D.Impulse);
		}

		private void OnSkillObjectCollisionEnter(GameObject skillObject){
			var rigidbody2D = skillObject.GetComponent<Rigidbody2D>();
			rigidbody2D.Sleep();
			DelayExplode(500, skillObject);
		}

		private async void DelayExplode(int delayTime, GameObject skillObject){
			await Task.Delay(delayTime);
			if(!skillObject) return;
			var skillObjectPosition = skillObject.transform.position;
			var colliders = Physics2D.OverlapCircleAll(skillObjectPosition, 2.5f);
			foreach(var nearObjectCollider in colliders){
				var rigidbodyComponent = nearObjectCollider.GetComponent<Rigidbody2D>();
				var modifyHp = nearObjectCollider.GetComponent<IModifyHp>();
				modifyHp?.ModifyHp(-10f);
				if(rigidbodyComponent == null) continue;
				var forceDirection = -skillObjectPosition.normalized;
				rigidbodyComponent.AddForce(forceDirection * 3, ForceMode2D.Impulse);
			}

			Destroy(skillObject);
		}
	}
}