using UnityEngine;

namespace Script.Main.Character.Interface{
	public interface IAttack{
		void Attack(Vector2 attackDirection, Vector2 targetPosition);
	}
}