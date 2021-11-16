using System.Threading.Tasks;
using Script.Main.Character;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Script.Main.Skill.SkillData.FireBall2D{
	public class FireBall2D : AbstractSkillData{
		[SerializeField] private GameObject fireballViewObject;

		private GameObject _fireballSkillObject;

		private SkillSpawnInfo SpawnInfo{ get; set; }

		public override void CastSkill(SkillSpawnInfo spawnInfo){
			SpawnInfo = spawnInfo;
			var originPosition = SpawnInfo.OriginPosition;
			_fireballSkillObject = Instantiate(fireballViewObject, originPosition, Quaternion.identity);
			_fireballSkillObject.OnCollisionEnter2DAsObservable()
					.Subscribe(OnSkillObjectCollisionEnter)
					.AddTo(_fireballSkillObject);
			_fireballSkillObject.OnEnableAsObservable()
					.Subscribe(x => OnSkillObjectCreated())
					.AddTo(_fireballSkillObject);
		}

		public void OnSkillObjectCreated(){
			var direction = SpawnInfo.Direction;
			var rigidbody2D = _fireballSkillObject.GetComponent<Rigidbody2D>();
			rigidbody2D.AddForce(direction * 10, ForceMode2D.Impulse);
		}

		private void OnSkillObjectCollisionEnter(Collision2D other){
			var rigidbody2D = _fireballSkillObject.GetComponent<Rigidbody2D>();
			rigidbody2D.Sleep();
			DelayExplode(500);
		}

		private async void DelayExplode(int delayTime){
			await Task.Delay(delayTime);
			var skillObjectPosition = _fireballSkillObject.transform.position;
			var colliders = Physics2D.OverlapCircleAll(skillObjectPosition, 2.5f);
			foreach(var nearObjectCollider in colliders){
				var rigidbodyComponent = nearObjectCollider.GetComponent<Rigidbody2D>();
				var modifyHp = nearObjectCollider.GetComponent<IModifyHp>();
				modifyHp?.ModifyHp(-10f);
				if(rigidbodyComponent == null) continue;
				var forceDirection = -skillObjectPosition.normalized;
				rigidbodyComponent.AddForce(forceDirection * 3, ForceMode2D.Impulse);
			}

			Destroy(_fireballSkillObject);
		}
	}
}