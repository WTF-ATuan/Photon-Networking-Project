using System;
using Script.Main.InputData.Event;
using UnityEngine;

namespace Script.Main.Character{
	public class Character : MonoBehaviour{
		private CharacterMovement _movement;

		private void Start(){
			_movement = GetComponent<CharacterMovement>();
			EventBus.Subscribe<MoveInputDetected>(OnMoveInputDetected);
		}

		private void OnMoveInputDetected(MoveInputDetected obj){
			var horizontal = obj.Horizontal;
			var vertical = obj.Vertical;
			_movement.Move(horizontal, vertical);
			_movement.SetFaceDirection(horizontal);
		}
	}
}