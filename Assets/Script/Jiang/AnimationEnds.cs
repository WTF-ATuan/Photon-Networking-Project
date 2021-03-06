using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnds : MonoBehaviour
{
    public GameObject VideoPlayer; // 影片撥放器
    public GameObject BattleUI; // 起始場景UI

    float VideoDuration = 19; // 劇情影片時長

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
