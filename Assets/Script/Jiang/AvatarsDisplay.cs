using System.Collections;
using System.Collections.Generic;
using Script.Main;
using Script.Main.Character.Event;
using UnityEngine;
using UnityEngine.UI;

public class AvatarsDisplay : MonoBehaviour{
	public Image AvatarImage;
	//public Image AvatarIntroduce;
	public Button RollSkill;
	public Button BaseSkill;
	//public Button StrongSkill;

        //Todo 換方式呈現
	//public Image SkillIntroduce;

	SpriteState Roll = new SpriteState();
	SpriteState Base = new SpriteState();
	SpriteState Strong = new SpriteState();


	public static string ChickWhichSkillntroduce;

	public Avatars[] avatars = new Avatars[4];
	//public static int NumOfAvatarsArray;
	public int NumOfAvatarsArray;
	Avatars avatar;

	void Start(){
		avatar = avatars[0];
	}

	void FixedUpdate(){
		avatar = avatars[NumOfAvatarsArray];

		//AvatarImage.sprite = avatar.AvatarImage;
		gameObject.GetComponent<Image>().sprite = avatar.AvatarImage;
		//AvatarIntroduce.sprite = avatar.AvatarIntroduce;
		RollSkill.image.sprite = avatar.RollSkill;
		BaseSkill.image.sprite = avatar.BaseSkill;
		//StrongSkill.image.sprite = avatar.StrongSkill;

        
 		Roll.highlightedSprite = avatar.RollSkillDisabled;
		Base.highlightedSprite = avatar.BaseSkillDisabled;
		//Strong.highlightedSprite = avatar.StrongSkillDisabled;

		Roll.disabledSprite = avatar.RollSkillDisabled;
		Base.disabledSprite = avatar.BaseSkillDisabled;
		//Strong.disabledSprite = avatar.StrongSkillDisabled;

		RollSkill.spriteState = Roll;
		BaseSkill.spriteState = Base;
		//StrongSkill.spriteState = Strong;

        //Todo 要換方式呈現
        // if (ChickWhichSkillntroduce == "RollSkill"){
		//	SkillIntroduce.sprite = avatar.IntroductionOfRollSkill;
		//}
		//else if(ChickWhichSkillntroduce == "BaseSkill"){
		//	SkillIntroduce.sprite = avatar.IntroductionOfBaseSkill;
		//}
		//else if(ChickWhichSkillntroduce == "StrongSkill"){
		//	SkillIntroduce.sprite = avatar.IntroductionOfStrongSkill;
		//}
	}

	public void ChooseCharacter(int indexOfPlayer){
		var characterData = avatars[NumOfAvatarsArray];
		var characterPrefab = characterData.characterPrefab;
		EventBus.DynamicPost(new CharacterChosen(characterPrefab, indexOfPlayer));
	}
}