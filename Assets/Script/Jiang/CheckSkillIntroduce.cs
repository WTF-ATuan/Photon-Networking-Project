using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckSkillIntroduce : MonoBehaviour
{
    public static Button AlreadyPressed;
    
    public void ButtonSetting()
    {
        AvatarsDisplay.ChickWhichSkillntroduce = gameObject.name;
        
        if(AlreadyPressed)
        {
            AlreadyPressed.interactable = true;
        }
        
        gameObject.GetComponent<Button>().interactable = false;
        AlreadyPressed = gameObject.GetComponent<Button>();
    }
}
