using Photon.Bolt;
using Script.Main.Character.Event.ViewEvent;

namespace Script.Main.Character.Component{
	public class CharacterViewEventHandler : EntityBehaviour<ICharacterState>{
		private string CharacterID{ get; set; }

		public override void Attached(){
			CharacterID = GetComponent<Character>().characterID;
			EventBus.Subscribe<PositionUpdated>(OnCharacterPositionUpdated);
			EventBus.Subscribe<FaceDirectionFlipped>(OnCharacterFaceDirectionFlipped);
			state.SetTransforms(state.CharacterTranform, transform);
		}

		private void OnCharacterPositionUpdated(PositionUpdated obj){
			var characterID = obj.CharacterID;
			if(!string.Equals(characterID, CharacterID)) return;
			var updatePosition = obj.UpdatePosition;
			transform.position = updatePosition;
		}

		private void OnCharacterFaceDirectionFlipped(FaceDirectionFlipped obj){
			var characterID = obj.CharacterID;
			if(!string.Equals(characterID, CharacterID)) return;
			var rotation = obj.Rotation;
			transform.eulerAngles = rotation;
		}
	}
}