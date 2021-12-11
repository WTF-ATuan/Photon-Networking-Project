namespace Script.Main.Character.Event{
	public class CharacterHealthModified{
		public string CharacterID{ get; }
		public int CurrentHealth{ get; }
		public int ModifyAmount{ get; }

		public CharacterHealthModified(string characterID , int currentHealth , int modifyAmount){
			CharacterID = characterID;
			CurrentHealth = currentHealth;
			ModifyAmount = modifyAmount;
		}
	}
}