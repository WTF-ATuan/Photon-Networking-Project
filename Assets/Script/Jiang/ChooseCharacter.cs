using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCharacter : MonoBehaviour
{
    public int ForCount;
    
    public void ButtonClick()
    {
        if (gameObject.name == "Right")
        {
            RightButton();
        }
        else if (gameObject.name == "Left")
        {
            LeftButton();
        }
    }

    public void RightButton()
    {
        ForCount = AvatarsDisplay.NumOfAvatarsArray;
        ForCount++;

        if (ForCount > 3)
        {
            ForCount = 0;
        }

        AvatarsDisplay.NumOfAvatarsArray =ForCount;
    }

   public  void LeftButton()
    {
        ForCount = AvatarsDisplay.NumOfAvatarsArray;
        ForCount--;

        if (ForCount < 0)
        {
            ForCount = 3;
        }

        AvatarsDisplay.NumOfAvatarsArray = ForCount;
    }
}
