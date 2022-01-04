using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CheckSkillIntroduce : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static Button AlreadyPressed;

    //public void ButtonSetting()
    //{
    //    AvatarsDisplay.ChickWhichSkillntroduce = gameObject.name;

    //    if(AlreadyPressed)
    //    {
    //        AlreadyPressed.interactable = true;
    //    }

    //    gameObject.GetComponent<Button>().interactable = false;
    //    AlreadyPressed = gameObject.GetComponent<Button>();
    //}
    
    public void OnPointerEnter(PointerEventData eventData)    //·Æ¹«²¾¤J
    {
        gameObject.GetComponentInParent<AvatarsDisplay>().CheckSkill = true;
        AvatarsDisplay.ChickWhichSkillntroduce = gameObject.name;
    }
    public void OnPointerExit(PointerEventData eventData)    //·Æ¹«²¾¥X
    {
        gameObject.GetComponentInParent<AvatarsDisplay>().CheckSkill = false;
    }
}
