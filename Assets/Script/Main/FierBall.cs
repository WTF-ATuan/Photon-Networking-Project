using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FierBall : MonoBehaviour
{
    Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Initialize()
    {
        
    }

    void Update()
    {
        rigidbody.AddForce(transform.right*10);
    }
}
