
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void EnterButton()
    {
        SceneManager.LoadScene(1);
    }
}
