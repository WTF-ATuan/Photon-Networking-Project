using System;
using System.Collections.Generic;
using Script.Main.Character.Interface;
using UnityEngine;

namespace Script.Main.Character{
	public class CharacterAbility : MonoBehaviour, ICharacterAbility{
		[SerializeField] private float moveSpeed;
		[SerializeField] private float damage;
		[SerializeField] private float jumpForce;

		private Dictionary<CharacterAbilityType, float> _stateRepository = new Dictionary<CharacterAbilityType, float>();

		private void Start(){
			SetDefaultState();
		}

		public void SetDefaultState(){
			_stateRepository.Add(CharacterAbilityType.MoveSpeed, moveSpeed);
			_stateRepository.Add(CharacterAbilityType.Damage, damage);
			_stateRepository.Add(CharacterAbilityType.JumpForce, jumpForce);
		}

		public float QueryAbility(CharacterAbilityType abilityType){
			var containsKey = _stateRepository.ContainsKey(abilityType);
			if(!containsKey) throw new Exception($"{abilityType} is not in repository");
			var value = _stateRepository[abilityType];
			return value;
		}

		public void ModifyAbility(CharacterAbilityType abilityType, float amount){
			var containsKey = _stateRepository.ContainsKey(abilityType);
			if(!containsKey) throw new Exception($"{abilityType} is not in repository");
			var value = _stateRepository[abilityType];
			value += amount;
			_stateRepository[abilityType] = value;
		}
	}

	public enum CharacterAbilityType{
		MoveSpeed,
		Damage,
		JumpForce
	}
}