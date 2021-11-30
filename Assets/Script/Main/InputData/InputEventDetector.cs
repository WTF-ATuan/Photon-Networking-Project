﻿using Script.Main.InputData.Event;
using UnityEngine;

namespace Script.Main.InputData{
	public class InputEventDetector : MonoBehaviour{
		public string OwnerID{ get; private set; }

		public void Init(string ownerId){
			OwnerID = ownerId;
		}

		private void Update(){
			if(string.IsNullOrEmpty(OwnerID)){
				return;
			}

			DetectMoveInput();
			DetectBaseSkillInput();
			DetectStrongSkillInput();
		}

		private void DetectMoveInput(){
			var horizontalValue = Input.GetAxisRaw($"Horizontal");
			var verticalValue = Input.GetAxisRaw($"Vertical");
			var isTumbleRoll = Input.GetKeyDown(KeyCode.Space);
			EventBus.Post(new MoveInputDetected(OwnerID, horizontalValue, verticalValue, isTumbleRoll));
		}

		private void DetectBaseSkillInput(){
			if(Input.GetMouseButtonDown(0)){
				EventBus.Post(new BaseSkillDetected(OwnerID, MouseWorldDirection()));
			}
		}

		private void DetectStrongSkillInput(){
			if(Input.GetMouseButtonDown(1)){
				EventBus.Post(new StrongSkillDetected(OwnerID, MouseWorldDirection()));
			}
		}

		private Vector3 MouseWorldDirection(){
			if(Camera.main == null) return Vector3.zero;
			var mousePos = Input.mousePosition;
			mousePos.z = -Camera.main.transform.position.z;
			var worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
			return worldPosition;
		}
	}
}