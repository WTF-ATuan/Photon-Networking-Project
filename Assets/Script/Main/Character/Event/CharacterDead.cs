namespace Script.Main.Character.Event{
	public class CharacterDead{
		public string CharacterID{ get; }

		public CharacterDead(string characterID){
			CharacterID = characterID;
		}
	}
}