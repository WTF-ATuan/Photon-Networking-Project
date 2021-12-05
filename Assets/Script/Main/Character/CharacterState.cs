using System.Collections.Generic;

namespace Script.Main.Character{
	public class CharacterState{
		private bool _isGround;
		private bool _isDead;

		private readonly Dictionary<CharacterStateType, bool> _stateRepository =
				new Dictionary<CharacterStateType, bool>();

		public void SetDefaultState(){
			_stateRepository.Add(CharacterStateType.IsGround, _isGround);
			_stateRepository.Add(CharacterStateType.IsDead, _isDead);
		}
	}

	public enum CharacterStateType{
		IsGround,
		IsDead
	}
}