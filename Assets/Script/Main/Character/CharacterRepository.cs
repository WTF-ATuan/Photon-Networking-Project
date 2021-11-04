using System;
using System.Collections.Generic;

namespace Script.Main.Character{
	public class CharacterRepository{
		private readonly Dictionary<string, Character> _characters = new Dictionary<string, Character>();

		public void Save(string characterID, Character character){
			var containsKey = _characters.ContainsKey(characterID);
			if(containsKey){
				throw new Exception($"Character : {characterID} have same ID ");
			}

			_characters.Add(characterID, character);
		}

		public Character Query(string characterID){
			var containsKey = _characters.ContainsKey(characterID);
			if(!containsKey) throw new Exception($"can,t Find this Character : {characterID}");
			var character = _characters[characterID];
			return character;
		}
	}
}