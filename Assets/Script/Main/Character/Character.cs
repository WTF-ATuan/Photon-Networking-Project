﻿using Script.Main.Character.Event;
using Script.Main.InputData.Event;
using Script.Main.Skill;
using Script.Main.Utility;
using UnityEngine;

namespace Script.Main.Character{
	public class Character : MonoBehaviour{
		public string characterID = "123";
		[SerializeField] private float startEnergyValue;

		private CharacterMovement _movement;
		private CharacterRepository _repository;
		private CharacterEventHandler _eventHandler;
		private Energy _energy;

		private string _baseSkillName = "FireBall";
		private string _strongSkillName = "FireBall2D";

		private void Start(){
			_movement = GetComponent<CharacterMovement>();
			_repository = SingleRepository.QueryObject<CharacterRepository>();
			_eventHandler = SingleRepository.QueryObject<CharacterEventHandler>();
			_energy = new Energy("123", startEnergyValue);
			_repository.Save(characterID, this);
			// EventBus.Subscribe<MoveInputDetected>(OnMoveInputDetected);
			// EventBus.Subscribe<BaseSkillDetected>(OnBaseSkillDetected);
			// EventBus.Subscribe<StrongSkillDetected>(OnStrongSkillDetected);
		}

		private void OnMoveInputDetected(MoveInputDetected obj){
			var horizontal = obj.Horizontal;
			var vertical = obj.Vertical;
			_movement.Move(horizontal, vertical);
			if(horizontal != 0){
				_movement.SetFaceDirection(horizontal);
			}
		}

		public void Move(float horizontal, float vertical){
			_movement.Move(horizontal, vertical);
		}

		public void SetFaceDirection(float direction){
			_movement.SetFaceDirection(direction);
		}

		private void OnBaseSkillDetected(BaseSkillDetected obj){
			var currentEnergyValue = _energy.GetCurrentEnergyValue();
			var direction = obj.MouseWorldPosition * 10;
			EventBus.Post(new SkillCasted(_baseSkillName,
				new SkillSpawnInfo("123", transform.position, direction)));
		}

		public void CastSkill(Vector2 direction, bool isBase){
			if(isBase){
				EventBus.Post(new SkillCasted(_baseSkillName,
					new SkillSpawnInfo("123", transform.position, direction)));
			}
			else{
				EventBus.Post(new SkillCasted(_strongSkillName,
					new SkillSpawnInfo("123", transform.position, direction)));
			}
		}

		private void OnStrongSkillDetected(StrongSkillDetected obj){
			var currentEnergyValue = _energy.GetCurrentEnergyValue();
			var direction = obj.MouseWorldPosition;
			EventBus.Post(new SkillCasted(_strongSkillName, new SkillSpawnInfo("123", transform.position, direction)));
		}
	}
}