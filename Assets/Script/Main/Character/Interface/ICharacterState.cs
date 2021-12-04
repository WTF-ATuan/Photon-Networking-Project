namespace Script.Main.Character.Interface{
	public interface ICharacterState{
		float QueryState(CharacterStateType stateType);
		void ModifyState(CharacterStateType stateType, float amount);
	}
}