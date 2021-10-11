using UnityEngine;

namespace Script.Main{
	public class UseSkill : MonoBehaviour{
		public GameObject fireBall;


		private void Update(){
			if(Input.GetKeyDown(KeyCode.Q)){
				CreateSkill();
			}
		}

		public void CreateSkill(){
			Instantiate(fireBall, gameObject.transform.position, Quaternion.identity);
		}
	}
}