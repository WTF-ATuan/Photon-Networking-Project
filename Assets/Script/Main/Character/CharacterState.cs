using System;
using System.Collections.Generic;
using Script.Main.Character.Interface;
using UnityEngine;

namespace Script.Main.Character{
	public class CharacterState : MonoBehaviour, ICharacterState{
		[SerializeField] private float moveSpeed;
		[SerializeField] private float damage;
		[SerializeField] private float jumpForce;

		private Dictionary<CharacterStateType, float> _stateRepository = new Dictionary<CharacterStateType, float>();

		private void Start(){
			SetDefaultState();
		}

		public void SetDefaultState(){
			_stateRepository.Add(CharacterStateType.MoveSpeed, moveSpeed);
			_stateRepository.Add(CharacterStateType.Damage, damage);
			_stateRepository.Add(CharacterStateType.JumpForce, jumpForce);
		}

		public float QueryState(CharacterStateType stateType){
			var containsKey = _stateRepository.ContainsKey(stateType);
			if(!containsKey) throw new Exception($"{stateType} is not in repository");
			var value = _stateRepository[stateType];
			return value;
		}

		public void ModifyState(CharacterStateType stateType, float amount){
			var containsKey = _stateRepository.ContainsKey(stateType);
			if(!containsKey) throw new Exception($"{stateType} is not in repository");
			var value = _stateRepository[stateType];
			value += amount;
			_stateRepository[stateType] = value;
		}
	}

	public enum CharacterStateType{
		MoveSpeed,
		Damage,
		JumpForce
	}
}