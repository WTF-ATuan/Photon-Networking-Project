using Photon.Bolt;
using Script.Main.Character.Event.ViewEvent;

namespace Script.Main.Character.Component{
	public class CharacterViewEventHandler : EntityBehaviour<ICharacterState>{
		private string CharacterID{ get; set; }

		public override void Attached(){
			CharacterID = GetComponent<Character>().characterID;
			EventBus.Subscribe<PositionUpdated>(OnCharacterPositionUpdated);
			EventBus.Subscribe<FaceDirectionFliped>(OnCharacterFaceDirectionModified);
			state.SetTransforms(state.CharacterTranform, transform);
		}

		private void OnCharacterPositionUpdated(PositionUpdated obj){
			var characterID = obj.CharacterID;
			if(!string.Equals(characterID, CharacterID)) return;
			var updatePosition = obj.UpdatePosition;
			transform.position = updatePosition;
		}

		private void OnCharacterFaceDirectionModified(FaceDirectionFliped obj){
			var characterID = obj.CharacterID;
			if(!string.Equals(characterID, CharacterID)) return;
			var localScale = obj.LocalScale;
			transform.localScale = localScale;
		}
	}
}