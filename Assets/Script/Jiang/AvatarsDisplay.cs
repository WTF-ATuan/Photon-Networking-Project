using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarsDisplay : MonoBehaviour
{
    public Image AvatarImage;
    public Image AvatarIntroduce;
    public Image SkillIRollSkill;
    public Image BaseSkill;
    public Image StrongSkill;
    public Image SkillIntroduce;

    public static  string ChickWhichSkillntroduce;

    public Avatars[] avatars = new Avatars[4];
    Avatars avatar;


    void Start()
    {
        AvatarImage.sprite = avatar.AvatarImage;
        AvatarIntroduce.sprite = avatar.AvatarIntroduce;
        SkillIRollSkill.sprite = avatar.SkillIRollSkill;
        BaseSkill.sprite = avatar.BaseSkill;
        StrongSkill.sprite = avatar.StrongSkill;
    }

    void FixedUpdate()
    {
        if (ChickWhichSkillntroduce == "SkillIRollSkill")
        {
            SkillIntroduce.sprite = avatar.IntroductionOfSkillIRollSkill;
        }
        else if (ChickWhichSkillntroduce == "BaseSkill")
        {
            SkillIntroduce.sprite = avatar.IntroductionOfBaseSkill;
        }
        else if (ChickWhichSkillntroduce == "StrongSkill")
        {
            SkillIntroduce.sprite = avatar.IntroductionOfStrongSkill;
        }
    }
}
