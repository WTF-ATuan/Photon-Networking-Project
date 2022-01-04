using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCharacter : MonoBehaviour{
	public int ForCount;

	public void RightButton(){
        ForCount = transform.parent.GetComponent<AvatarsDisplay>().NumOfAvatarsArray;

        ForCount++;

		if(ForCount > 3){
			ForCount = 0;
		}

		transform.parent.GetComponent<AvatarsDisplay>().NumOfAvatarsArray = ForCount;
	}

	public void LeftButton(){
        ForCount = transform.parent.GetComponent<AvatarsDisplay>().NumOfAvatarsArray;

        ForCount--;

		if(ForCount < 0){
			ForCount = 3;
		}

        transform.parent.GetComponent<AvatarsDisplay>().NumOfAvatarsArray = ForCount;
    }
}