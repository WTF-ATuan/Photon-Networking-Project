using UnityEngine;
using UnityEngine.UI ;

namespace Script.Main.Character{
	public class Enemy : MonoBehaviour , IModifyHp{
		public float hp = 100;
        public Image HPbar;

		public void ModifyHp(float amount){
			hp += amount;

            HPbar.GetComponent<RectTransform>().sizeDelta= new Vector2(hp -amount, 10);
		}
	}

	public interface IModifyHp{
		void ModifyHp(float amount);


	}

    
}