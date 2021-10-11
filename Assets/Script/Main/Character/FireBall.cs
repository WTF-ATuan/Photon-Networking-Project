using UnityEngine;

namespace Script.Main{
	public class FireBall : MonoBehaviour{
		private Rigidbody _rigidbody;

		private void Start(){
			_rigidbody = GetComponent<Rigidbody>();
		}
		
		private void Update(){
			_rigidbody.AddForce(transform.right * 10);
		}
	}
}