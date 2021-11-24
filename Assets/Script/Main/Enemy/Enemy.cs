using UnityEngine;
using UnityEngine.UI;

namespace Script.Main.Enemy{
	public class Enemy : MonoBehaviour, IModifyHp{
		public float hp = 100;
		public Image hpBar;

		public void ModifyHp(float amount){
			hp += amount;
			hpBar.GetComponent<RectTransform>().sizeDelta = new Vector2(hp - amount, 10);
			if(hp <= 0){
				gameObject.SetActive(false);
			}
		}
	}

	public interface IModifyHp{
		void ModifyHp(float amount);
	}
}