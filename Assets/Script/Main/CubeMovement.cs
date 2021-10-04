using Photon.Pun;
using Unity.Collections;
using UnityEngine;

namespace Script.Main{
	public class CubeMovement : MonoBehaviour
	{
		[ReadOnly] [SerializeField]
		private string userId;
		
		//test
		private PhotonView _viewComponent;
		private void Start(){
			userId = PhotonNetwork.LocalPlayer.UserId;
			_viewComponent = GetComponent<PhotonView>();
		}


		private void Update(){
			if(!_viewComponent.IsMine) return;
			var horizontalValue = Input.GetAxisRaw("Horizontal");
			var verticalValue = Input.GetAxisRaw("Vertical");
			Move(horizontalValue , verticalValue);
		}

		private void Move(float moveX, float moveY){
			var velocity = new Vector2(moveX , moveY) * 0.05f;
			var position = transform.position;
			position = new Vector3(position.x + velocity.x, position.y + velocity.y,
				position.z);
			transform.position = position;
		}
	}
}
