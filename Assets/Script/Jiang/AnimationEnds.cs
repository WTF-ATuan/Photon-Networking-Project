using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnds : MonoBehaviour
{
    public GameObject VideoPlayer; // �v������
    public GameObject BattleUI; // �_�l����UI

    float VideoDuration = 19; // �@���v���ɪ�

    void Start()
    {
        if (ButtonSetting.GameOverBackStart)
        {
            End();
        }
        else
        {
            Invoke("End", VideoDuration);
        }
    }
    
 public void End()
    {
        VideoPlayer.SetActive(false);
        BattleUI.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            End();
        }
    }
}
