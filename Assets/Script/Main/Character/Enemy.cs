using UnityEngine;

namespace Script.Main.Character{
	public class Enemy : MonoBehaviour , IModifyHp{
		public float hp = 100;

		public void ModifyHp(float amount){
			hp += amount;
		}
	}

	public interface IModifyHp{
		void ModifyHp(float amount);
	}
}