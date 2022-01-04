using UnityEngine;
using UnityEngine.UI;

namespace Script.Jiang.Buttons{
	public class CloseGame : MonoBehaviour{

        public Sprite win;
        public Sprite fail;

		public void Win(){
            gameObject.GetComponent<Image>().sprite = win;
		}
        public void Fail()
        {
            gameObject.GetComponent<Image>().sprite = fail;
        }
    }
}