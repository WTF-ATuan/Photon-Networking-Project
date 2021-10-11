using UnityEngine;

namespace Script.Main{
	public class CharacterSkill : MonoBehaviour{
		public GameObject fireBall;

		public void CreateBaseSkill(string characterID){
			Instantiate(fireBall, gameObject.transform.position, Quaternion.identity);
		}

		public void CreateStrongSkill(string characterID){
			
		}
	}
}