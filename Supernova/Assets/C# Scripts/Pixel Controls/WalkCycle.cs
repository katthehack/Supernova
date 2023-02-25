using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WalkCycle : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Sprite[] up; //8 sprites 
    public Sprite[] down; //8 sprites 
    public Sprite[] left; //13 sprites 
    public Sprite[] right; //13 sprites 

    int walkCycle;
    int frame;
    KeyCode lastKey; //used to determine still frame

    float speed;
    Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Player";
        frame = 1;
        walkCycle = 0; 
        speed = 0.03f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Math.Abs(Input.GetAxis("Horizontal")) > Math.Abs(Input.GetAxis("Vertical"))) //x axis movement
        {
            move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            if(frame % 24 == 0)
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    if (walkCycle > 11) walkCycle = 0;
                    spriteRenderer.sprite = right[walkCycle];
                    walkCycle++;
                    lastKey = KeyCode.D;
                }
                else
                {
                    if (walkCycle > 11) walkCycle = 0;
                    spriteRenderer.sprite = left[walkCycle];
                    walkCycle++;
                    lastKey = KeyCode.A;
                }
            }
        }
        else if(Math.Abs(Input.GetAxis("Vertical")) > Math.Abs(Input.GetAxis("Horizontal")))//y axis movement
        {
            move = new Vector3(0, Input.GetAxis("Vertical"), 0);
            if(frame % 24 == 0)
            {
                if (Input.GetAxis("Vertical") > 0)
                {
                    if (walkCycle > 6) walkCycle = 0;
                    spriteRenderer.sprite = up[walkCycle];
                    walkCycle++;
                    lastKey = KeyCode.W;
                }
                else
                {
                    if (walkCycle > 6) walkCycle = 0;
                    spriteRenderer.sprite = down[walkCycle];
                    walkCycle++;
                    lastKey= KeyCode.S;
                }
            }
        }
        else 
        {
            move = new Vector3(0, 0, 0);
            if(frame % 24 == 0)
            {
                walkCycle = 0;
                if(lastKey == KeyCode.S)
                {
                    spriteRenderer.sprite = down[7];
                }
                else if(lastKey == KeyCode.W)
                {
                    spriteRenderer.sprite = up[7];
                }
                else if (lastKey == KeyCode.D)
                {
                    spriteRenderer.sprite = right[12];
                }
                else if (lastKey == KeyCode.A)
                {
                    spriteRenderer.sprite = left[12];
                }
            }
        }
        transform.position += move * speed;
        frame++; 
    }
}