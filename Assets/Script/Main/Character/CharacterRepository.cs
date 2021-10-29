﻿using System;
using System.Collections.Generic;

namespace Script.Main.Character{
	public class CharacterRepository{
		private Dictionary<string, Character> _characters = new Dictionary<string, Character>();

		public void Save(string characterID, Character character){
			var containsKey = _characters.ContainsKey(characterID);
			if(containsKey){
				throw new Exception($"Character : {characterID} have same ID ");
			}

			_characters.Add(characterID, character);
		}

		public Character Query(string characterID){
			var character = _characters[characterID];
			return character ? character : default;
		}
	}
}