namespace Script.Main.Character.Event{
	public class CharacterAnimated{
		public string CharacterID{ get; }
		public string AnimationName{ get; }
		public float AnimationTimeScale{ get; }

		public CharacterAnimated(string characterID, string animationName, float animationTimeScale = 1){
			CharacterID = characterID;
			AnimationName = animationName;
			AnimationTimeScale = animationTimeScale;
		}
	}
}