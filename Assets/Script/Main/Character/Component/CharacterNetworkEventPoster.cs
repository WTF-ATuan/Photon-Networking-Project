using Photon.Bolt;
using Script.Main.Character.Interface;

namespace Script.Main.Character.Component{
	public class CharacterNetworkEventPoster : EntityBehaviour<ICharacterState> , ICharacterIdentity{
		private string CharacterID{ get; set; }

		public void SetCharacterID(string characterID){
			CharacterID = characterID;
		}

		public override void Attached(){
			
		}
	}
}