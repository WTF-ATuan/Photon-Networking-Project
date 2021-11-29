
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSetting : MonoBehaviour    //�H���s�W�٧P�_���F������s    �H�����W�٧���n����������
{
    public GameObject MenuPrefab;  //�I�}���� �X�{�����
    public GameObject VolumeControl;  //�վ㭵�q������
    public GameObject OriginalCanvas;  //�վ㭵�q���������}�� �����canvas����
    public static string GetButtonName; //�I�������s�W��

    public void ButtonIsClick()
    {
        Debug.Log("00");

        if (GetButtonName == "Button_GameStart")
        {
            SceneManager.LoadScene("SeverConnect");
        }

        if (GetButtonName == "Button_QuitGame")
        {
            Application.Quit();
        }
        
        if (GetButtonName == "Button_BackToStart")
        {
            SceneManager.LoadScene("StartScenes");
        }

        if (GetButtonName == "Button_BackToCreateOrJoin")
        {
            SceneManager.LoadScene("CreateOrJoin");
        }

        if (GetButtonName == "Button_VolumeSetting")
        {
            OriginalCanvas = GameObject.Find("Canvas");
            OriginalCanvas.SetActive(false);
            VolumeControl.SetActive(true);
        }

        if (GetButtonName == "Button_CloseVolumeSetting")
        {
            OriginalCanvas.SetActive(true);
            VolumeControl.SetActive(false);
        }

        //if (GetButtonName == "Button_EnterRoom")
        //{
        //    SceneManager.LoadScene(3);
        //}

        //if (GetButtonName == "Button_CreateRoom")
        //{
        //    SceneManager.LoadScene(3);
        //}

        if (GetButtonName == "Button_JoinRoom")
        {
            SceneManager.LoadScene("JoinSetting");
        }

        if (GetButtonName == "Button_CloseMenu")
        {
            Destroy(GameObject.Find("Menu"));
        }

        if (GetButtonName == "Button_OpenMenu")
        {
            Instantiate(MenuPrefab);
        }
    }
}
