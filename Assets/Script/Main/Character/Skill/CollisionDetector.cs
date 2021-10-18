using UnityEngine;

namespace Script.Main.Character.Skill{
	public class CollisionDetector : MonoBehaviour{
		public string OwnerID{ get; private set; }

		public void InitDetector(string ownerID){
			OwnerID = ownerID;
		}

		private void OnCollisionEnter(Collision other){ }

		private void OnCollisionExit(Collision other){ }

		private void OnCollisionEnter2D(Collision2D other){ }

		private void OnCollisionExit2D(Collision2D other){ }
	}
}