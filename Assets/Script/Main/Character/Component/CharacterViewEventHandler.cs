using Photon.Bolt;
using Script.Main.Character.Event.ViewEvent;

namespace Script.Main.Character.Component{
	public class CharacterViewEventHandler : EntityBehaviour<ICharacterState>{
		private string CharacterID{ get; set; }

		public override void Attached(){
			CharacterID = GetComponent<Character>().characterID;
			EventBus.Subscribe<PositionUpdated>(OnCharacterPositionUpdated);
			EventBus.Subscribe<FaceDirectionModified>(OnCharacterFaceDirectionModify);
		}

		private void OnCharacterPositionUpdated(PositionUpdated obj){
			var characterID = obj.CharacterID;
			if(!string.Equals(characterID, CharacterID)) return;
			var updatePosition = obj.UpdatePosition;
			var characterTransform = transform;
			characterTransform.position = updatePosition;
			state.SetTransforms(state.CharacterTranform, characterTransform);
		}

		private void OnCharacterFaceDirectionModify(FaceDirectionModified obj){
			var characterID = obj.CharacterID;
			if(!string.Equals(characterID, CharacterID)) return;
			var localScale = obj.LocalScale;
			var characterTransform = transform;
			characterTransform.localScale = localScale;
			state.SetTransforms(state.CharacterTranform, characterTransform);
		}
	}
}