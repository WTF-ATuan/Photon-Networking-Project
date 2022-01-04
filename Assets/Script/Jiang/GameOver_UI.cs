using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver_UI : MonoBehaviour
{
    float A;
    void Start()
    {
        A = 0;
        GetComponent<Image>().color = new Color(255, 255, 255, A);

        InvokeRepeating("AddA", 0, 0.05f);
    }
    

    void AddA()
    {
        if (A < 1)
        {
            A += 0.05f;
            GetComponent<Image>().color = new Color(255, 255, 255, A);
        }
    }
}
