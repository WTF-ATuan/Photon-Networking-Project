using System.Threading.Tasks;
using Script.Main.Character;
using UnityEngine;

namespace Script.Main.Skill.SkillData.FireBall2D{
	public class FireBall2D : AbstractSkill{
		private Rigidbody2D _rigidbody2D;

		public override void OnSkillCasted(SkillSpawnInfo spawnInfo){
			var originPosition = spawnInfo.OriginPosition;
			var skillObject = Instantiate(this, originPosition, Quaternion.identity);
			skillObject.OnSkillCreated(spawnInfo);
		}

		public override void OnSkillCreated(SkillSpawnInfo spawnInfo){
			var direction = spawnInfo.Direction;
			_rigidbody2D = GetComponent<Rigidbody2D>();
			_rigidbody2D.AddForce(direction * 10, ForceMode2D.Impulse);
		}

		private void OnCollisionEnter2D(Collision2D other){
			_rigidbody2D.Sleep();
			DelayExplode(500);
		}

		private async void DelayExplode(int delayTime){
			await Task.Delay(delayTime);
			var colliders = Physics2D.OverlapCircleAll(transform.position, 2.5f);
			foreach(var nearObjectCollider in colliders){
				var rigidbodyComponent = nearObjectCollider.GetComponent<Rigidbody2D>();
				var modifyHp = nearObjectCollider.GetComponent<IModifyHp>();
				modifyHp?.ModifyHp(-10f);
				if(rigidbodyComponent == null) continue;
				var forceDirection = -transform.position.normalized;
				rigidbodyComponent.AddForce(forceDirection * 3, ForceMode2D.Impulse);
			}
			Destroy(gameObject);
		}
	}
}