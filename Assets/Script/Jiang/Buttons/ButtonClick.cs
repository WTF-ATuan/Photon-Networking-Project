using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonClick : MonoBehaviour
{
    GameObject Buttons;
    private void Start()
    {
        Buttons = GameObject.Find("Buttons");
    }
    public void EnterButton()
    {
        ButtonSetting.GetButtonName = gameObject.name;

       Buttons.GetComponent<ButtonSetting>().ButtonIsClick();
    }
}
