using UnityEngine;

namespace Script.Main.Enemy.Interface{
	public interface IAttack{
		void SetTarget(Transform targetTransform);
		void Attack();
	}
}