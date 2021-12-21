using Photon.Bolt;
using Script.Main.Character.Event.ViewEvent;
using Script.Main.Character.Interface;
using UnityEngine;

namespace Script.Main.Character.Component{
	public class CharacterViewEventHandler : EntityBehaviour<ICharacterState>, ICharacterIdentity{
		private string CharacterID{ get; set; }

		public void SetCharacterID(string characterID){
			CharacterID = characterID;
		}

		public override void Attached(){
			EventBus.Subscribe<PositionUpdated>(OnCharacterPositionUpdated);
			EventBus.Subscribe<FaceDirectionFlipped>(OnCharacterFaceDirectionFlipped);
			state.SetTransforms(state.CharacterTranform, transform);
			state.SetAnimator(GetComponent<Animator>());
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