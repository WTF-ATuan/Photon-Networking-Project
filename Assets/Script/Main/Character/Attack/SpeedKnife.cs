using Photon.Bolt;
using Script.Main.Character.Interface;
using UnityEngine;

namespace Script.Main.Character.Attack{
	public class SpeedKnife : MonoBehaviour, IAttack{
		[SerializeField] private GameObject knifePre;
		[SerializeField] private float throwSpeed;
		

		private Character _character;

		private void Start(){
			_character = GetComponent<Character>();
		}

		public bool CanAttack(){
			return true;
		}

		public void Attack(Vector2 attackDirection, Vector2 targetPosition){
			
		}

		private void ThrowKnife(Rigidbody2D knifeRig , Vector2 direction){
			
		}
		private void OnSkillTriggered(BoltEntity skillObjectClone){ }
	}
}