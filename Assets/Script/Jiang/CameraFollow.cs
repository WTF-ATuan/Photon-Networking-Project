using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    public float smothing = 5f;   //鏡頭平滑移動的速度
    Vector3 offset;  //相機和主角之間的固定距離

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - Player.position;
    }

    void FixedUpdate()
    {
        Vector3 targetCampos = Player.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetCampos, smothing * Time.deltaTime);  //以一定的速度，從A平滑移動到B
    }
}

