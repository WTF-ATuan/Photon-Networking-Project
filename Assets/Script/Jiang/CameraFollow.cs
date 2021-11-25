using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    public float smothing = 5f;   //���Y���Ʋ��ʪ��t��
    Vector3 offset;  //�۾��M�D���������T�w�Z��

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - Player.position;
    }

    void FixedUpdate()
    {
        Vector3 targetCampos = Player.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetCampos, smothing * Time.deltaTime);  //�H�@�w���t�סA�qA���Ʋ��ʨ�B
    }
}

