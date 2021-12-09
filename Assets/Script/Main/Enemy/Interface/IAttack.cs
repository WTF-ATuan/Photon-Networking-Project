using UnityEngine;

namespace Script.Main.Enemy.Interface{
	public interface IAttack{
		bool IsReadyAttack(Transform targetTransform);
		void Attack();
	}
}