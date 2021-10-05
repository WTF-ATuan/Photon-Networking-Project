using Photon.Pun;
namespace Script.Main{
	public class SeverCallbackPoster : MonoBehaviourPunCallbacks{
		public override void OnConnectedToMaster(){
			var userId = PhotonNetwork.LocalPlayer.UserId;
			EventBus.Post(new SeverConnected(userId));
		}
	}
}