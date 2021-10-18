using UnityEngine;

namespace Script.Main.Character{
	public class Enemy : MonoBehaviour{
		public float hp = 100;

		public void ModifyHp(float amount){
			hp += amount;
		}
	}
}