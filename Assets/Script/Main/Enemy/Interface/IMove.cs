using UnityEngine;

namespace Script.Main.Enemy.Interface{
	public interface IMove{
		void Move(bool enable , Vector2 direction);
	}
}