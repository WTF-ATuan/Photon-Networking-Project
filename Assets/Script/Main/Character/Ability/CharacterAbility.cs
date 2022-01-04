using System;
using System.Collections.Generic;
using Script.Main.Character.Interface;
using UnityEngine;

namespace Script.Main.Character{
	public class CharacterAbility : MonoBehaviour, ICharacterAbility{
		[SerializeField] private float defaultMoveSpeed = 3;
		[SerializeField] private float defaultDamage = 2;
		[SerializeField] private float defaultJumpForce = 5;

		private readonly Dictionary<CharacterAbilityType, float>
				_abilityRepository = new Dictionary<CharacterAbilityType, float>();

		private void Awake(){
			SetDefaultAbility();
		}

		public void SetDefaultAbility(){
			_abilityRepository.Add(CharacterAbilityType.MoveSpeed, defaultMoveSpeed);
			_abilityRepository.Add(CharacterAbilityType.Damage, defaultDamage);
			_abilityRepository.Add(CharacterAbilityType.JumpForce, defaultJumpForce);
		}

		public float QueryAbility(CharacterAbilityType abilityType){
			var containsKey = _abilityRepository.ContainsKey(abilityType);
			if(!containsKey) throw new Exception($"{abilityType} is not in repository");
			var value = _abilityRepository[abilityType];
			return value;
		}

		public void ModifyAbility(CharacterAbilityType abilityType, float amount){
			var containsKey = _abilityRepository.ContainsKey(abilityType);
			if(!containsKey) throw new Exception($"{abilityType} is not in repository");
			var value = _abilityRepository[abilityType];
			value += amount;
			_abilityRepository[abilityType] = value;
		}
	}

	public enum CharacterAbilityType{
		MoveSpeed,
		Damage,
		JumpForce
	}
}