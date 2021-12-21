using UnityEngine;

namespace Script.Main.Character.Interface{
	public interface IAttack{
		bool CanAttack();
		void Attack(Vector2 attackDirection, Vector2 targetPosition);
	}
}