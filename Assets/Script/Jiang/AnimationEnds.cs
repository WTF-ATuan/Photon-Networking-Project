using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnds : MonoBehaviour
{
    public GameObject VideoPlayer; // �v������
    public GameObject BattleUI; // �_�l����UI

    float VideoDuration = 16; // �@���v���ɪ�

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
