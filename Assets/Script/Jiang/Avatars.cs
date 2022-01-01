using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Avatar", fileName = "NewAvatar")]
public class Avatars : ScriptableObject{
	public GameObject preBattleCharacter;
	public Sprite AvatarImage;
	public Sprite AvatarIntroduce;
	public Sprite RollSkill;
	public Sprite BaseSkill;
	public Sprite StrongSkill;
	public Sprite RollSkillDisabled;
	public Sprite BaseSkillDisabled;
	public Sprite StrongSkillDisabled;
	public Sprite IntroductionOfRollSkill;
	public Sprite IntroductionOfBaseSkill;
	public Sprite IntroductionOfStrongSkill;
}