namespace Script.Main.Character.Event{
	public class CharacterCreated{
		public string CharacterID{ get; }

		public CharacterCreated(string characterID){
			CharacterID = characterID;
		}
	}
}