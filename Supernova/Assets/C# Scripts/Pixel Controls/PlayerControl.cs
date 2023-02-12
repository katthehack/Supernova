using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerControl : MonoBehaviour
{
    float speed = 7.5f;
    Vector3 move;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Sol";
    }

    // Update is called once per frame
    void Update()
    {
        if(Math.Abs(Input.GetAxis("Horizontal")) > Math.Abs(Input.GetAxis("Vertical")))
        {
            move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        }
        else
        {
            move = new Vector3(0, Input.GetAxis("Vertical"), 0);
        }
        //move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        
        //vector3 holds values for x y and z
        //this gets current coordinates
        //if you remove time you go supersonic speed

        transform.position += move * speed * Time.deltaTime;
    }
}
