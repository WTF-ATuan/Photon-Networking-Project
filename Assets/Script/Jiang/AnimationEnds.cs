using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnds : MonoBehaviour
{
    public GameObject VideoPlayer; // 影片撥放器
    public GameObject BattleUI; // 戰鬥場景UI

    float VideoDuration = 5; // 劇情影片時長

    void Start()
    {
        Invoke("End",VideoDuration );
    }
    
    void End()
    {
        VideoPlayer.SetActive(false);
        BattleUI.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            VideoPlayer.SetActive(false);
            BattleUI.SetActive(true);
        }
    }
}
