namespace Script.Main.Character.Interface{
	public interface ICharacterAbility{
		float QueryAbility(CharacterAbilityType abilityType);
		void ModifyAbility(CharacterAbilityType abilityType, float amount);
	}
}