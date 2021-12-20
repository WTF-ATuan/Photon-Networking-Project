using Photon.Bolt;
using Script.Main.Character.Event.ViewEvent;

namespace Script.Main.Character.Component{
	public class CharacterViewEventHandler : EntityBehaviour<ICharacterState>{
		public override void Attached(){
			EventBus.Subscribe<PositionUpdated>(OnCharacterPositionUpdated);
			state.SetTransforms(state.CharacterTranform, transform);
		}

		private void OnCharacterPositionUpdated(PositionUpdated obj){
			var updatePosition = obj.UpdatePosition;
			transform.position = updatePosition;
		}
	}
}