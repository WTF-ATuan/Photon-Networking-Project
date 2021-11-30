using Script.Main.Enemy.Interface;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Script.Main.Skill.BasicArrow{
	public class BasicArrow : AbstractSkillData{
		[SerializeField] private GameObject arrowViewObject = null;
		[SerializeField] private float arrowSpeed = 10;


		public override void CastSkill(SkillSpawnInfo spawnInfo){
			var originPosition = spawnInfo.OriginPosition;
			var direction = spawnInfo.Direction;
			var skillObject = Instantiate(arrowViewObject, originPosition, Quaternion.identity);
			var rigidbody2D = skillObject.GetComponent<Rigidbody2D>();
			rigidbody2D.AddForce(direction * arrowSpeed, ForceMode2D.Impulse);
			skillObject.OnCollisionEnter2DAsObservable()
					.Subscribe(x => OnSkillObjectCollisionEnter(skillObject , x))
					.AddTo(skillObject);
		}

		private void OnSkillObjectCollisionEnter(GameObject skillObject, Collision2D other){
			var collisionGameObject = other.gameObject;
			var modifyHp = collisionGameObject.GetComponent<IModifyHp>();
			modifyHp?.ModifyHp(-10);
			Destroy(skillObject);
		}
	}
}