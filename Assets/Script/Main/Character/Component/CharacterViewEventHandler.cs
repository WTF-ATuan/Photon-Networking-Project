using Photon.Bolt;
using Script.Main.Character.Event;
using UnityEngine;

namespace Script.Main.Character.Component{
	public class CharacterViewEventHandler : EntityBehaviour<ICharacterState>{
		public override void Attached(){
			EventBus.Subscribe<CharacterMoved>(OnCharacterMoved);
			state.SetTransforms(state.CharacterTranform, transform);
		}

		private void OnCharacterMoved(CharacterMoved obj){
			var originPosition = obj.OriginPosition;
			var targetPosition = obj.TargetPosition;
			
		}
	}
}