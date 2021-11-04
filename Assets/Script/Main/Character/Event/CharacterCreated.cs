namespace Script.Main.Character.Event{
	public class CharacterCreated{
		public string CharacterID{ get; }
		public Character Character{ get; }

		public CharacterCreated(string characterID, Character character){
			CharacterID = characterID;
			Character = character;
		}
	}
}