using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonSetting : MonoBehaviour //以按鈕名稱判斷按了什麼按鈕    以場景名稱抓取要切換的場景
{
    public GameObject MenuPrefab; //點開齒輪 出現的選單
    public GameObject VolumeControl; //調整音量的介面
    public static string GetButtonName; //點擊的按鈕名稱


    public void ButtonIsClick()
    {
        if (GetButtonName == "Button_GameStart") {
            SceneManager.LoadScene("ChooseCharacter");
        }

        if (GetButtonName == "Button_QuitGame") {
            Application.Quit();
        }

        if (GetButtonName == "Button_BackToStart") {
            SceneManager.LoadScene("StartScenes");
        }

        //if (GetButtonName == "Button_BackToCreateOrJoin") {
        //    SceneManager.LoadScene("CreateOrJoin");
        //}

        if (GetButtonName == "Button_VolumeSetting") {
            VolumeControl.SetActive(true);
        }

        if (GetButtonName == "Button_CloseVolumeSetting") {
            VolumeControl.SetActive(false);
        }

        //if (GetButtonName == "Button_Join")
        //{
        //    SceneManager.LoadScene("ChooseCharacter");
        //}

        //if (GetButtonName == "Button_Create")
        //{
        //    SceneManager.LoadScene("ChooseCharacter");
        //}

        //if (GetButtonName == "Button_CreateRoom") {
        //    SceneManager.LoadScene("CreateSetting");
        //}

        //if (GetButtonName == "Button_JoinRoom") {
        //    SceneManager.LoadScene("JoinSetting");
        //}

        if (GetButtonName == "Button_CloseMenu") {
            Destroy(GameObject.Find("Menu"));
        }

        if (GetButtonName == "Button_OpenMenu" && GameObject.Find("Menu") == false) {
            Instantiate(MenuPrefab).name = "Menu";
        }

        //Todo 做好連線之後刪掉這邊，應該先判斷所有玩家是否都準備好了，才能進入戰鬥場景
        if (GetButtonName == "Finish") {
         SceneManager.LoadScene("Battle Scene_Offline");
        }
    }

    bool ReadyOrNot = false;
    public void Finish() {
        if (ReadyOrNot)
        {
            gameObject.GetComponent<Image>().sprite = gameObject.GetComponent<Button>().spriteState.highlightedSprite;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = gameObject.GetComponent<Button>().spriteState.pressedSprite;
        }
        GameObject.Find("Right").GetComponent<Button>().interactable = ReadyOrNot;
        GameObject.Find("Left").GetComponent<Button>().interactable = ReadyOrNot;

        ReadyOrNot = !ReadyOrNot;
    }
}