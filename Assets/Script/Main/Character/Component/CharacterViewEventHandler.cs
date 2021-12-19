using Photon.Bolt;
using Script.Main.Character.Event;

namespace Script.Main.Character.Component{
	public class CharacterViewEventHandler : EntityBehaviour<ICharacterState>{
		public override void Attached(){
			EventBus.Subscribe<CharacterPositionUpdated>(OnCharacterPositionUpdated);
			state.SetTransforms(state.CharacterTranform, transform);
		}

		private void OnCharacterPositionUpdated(CharacterPositionUpdated obj){
			var updatePosition = obj.UpdatePosition;
			transform.position = updatePosition;
		}
	}
}