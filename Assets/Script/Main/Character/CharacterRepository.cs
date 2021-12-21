using System;
using System.Collections.Generic;
using System.Linq;

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

		public bool ContainCharacter(string characterID){
			var containsKey = _characters.ContainsKey(characterID);
			return containsKey;
		}

		public List<Character> QueryAll(){
			var characters = _characters.Values.ToList();
			return characters;
		}
	}
}