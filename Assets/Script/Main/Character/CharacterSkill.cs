using UnityEngine;

namespace Script.Main{
	public class CharacterSkill : MonoBehaviour{
		public GameObject fireBall;
		
		public void CreateSkill(){
			Instantiate(fireBall, gameObject.transform.position, Quaternion.identity);
		}
	}
}