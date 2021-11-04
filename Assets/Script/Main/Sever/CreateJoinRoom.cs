using UnityEngine;
using UnityEngine.UI;

namespace Script.Main{
	public class CreateJoinRoom : MonoBehaviour{
		[SerializeField] private InputField field1;
		[SerializeField] private InputField field2;
		[SerializeField] private Sever sever;

		private void Start(){
			EventBus.Subscribe<RoomJoined>(OnJoinedRoom);
		}

		public void CreateRoom(){
			sever.CreateRoom(field1.text);
		}

		public void JoinedRoom(){
			sever.JoinRoom(field2.text);
		}

		private void OnJoinedRoom(RoomJoined obj){
			sever.LoadScene("Battle Scene");
		}
	}
}