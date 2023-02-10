using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    float speed = 7.5f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Sol";
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        //vector3 holds values for x y and z
        //this gets current coordinates
        //if you remove time you go supersonic speed
        transform.position += move * speed * Time.deltaTime;
    }
}
