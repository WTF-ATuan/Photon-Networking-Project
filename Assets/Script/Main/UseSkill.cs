using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSkill : MonoBehaviour
{
    public GameObject FireBall;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CreateSkill();
        }
    }

    public void CreateSkill()
    {
        Instantiate(FireBall, gameObject.transform.position, Quaternion.identity);
    }

}
