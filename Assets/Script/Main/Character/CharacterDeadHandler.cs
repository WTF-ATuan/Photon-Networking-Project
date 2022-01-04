using Script.Main.Character.Event;
using Script.Main.Utility;
using UnityEngine;
using UnityEngine.Events;

namespace Script.Main.Character{
	public class CharacterDeadHandler : MonoBehaviour{
		private CharacterRepository _repository;
		[SerializeField] private UnityEvent onCharacterAllDead;

		private void Start(){
			_repository = SingleRepository.Query<CharacterRepository>();
			EventBus.Subscribe<CharacterDead>(OnCharacterDead);
		}

		private void OnCharacterDead(CharacterDead obj){
			var characterID = obj.CharacterID;
			_repository.Remove(characterID);
			var isEmpty = _repository.Count() < 1;
			if(isEmpty){
				onCharacterAllDead?.Invoke();
			}
		}
	}
}