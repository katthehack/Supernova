using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;


public class ChangeSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    int walkCycleUp;
    int walkCycleDown;
    int walkCycleRight;
    int walkCycleLeft;
    int frame;
    KeyCode lastKey; //used to determine still frame

    // Start is called before the first frame update
    void Start()
    {
        frame = 1;
        walkCycleUp = 8;
        walkCycleDown = 0;
        walkCycleRight = 20;
        walkCycleLeft = 32;
    }
    // Update is called once per frame
    private void Update()
    {
        if (frame%35==0)
        {
            if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.UpArrow))
            {
                spriteRenderer.sprite = sprites[walkCycleUp];
                walkCycleUp++;
                lastKey = KeyCode.W;
                if (walkCycleUp > 15) walkCycleUp = 8;
            }
            else if (Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.DownArrow))
            {
                spriteRenderer.sprite = sprites[walkCycleDown];
                walkCycleDown++;
                if (walkCycleDown > 7) walkCycleDown = 0;
                lastKey= KeyCode.S;

            }
            else if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
            {
                spriteRenderer.sprite = sprites[walkCycleRight];
                walkCycleRight++;
                if (walkCycleRight > 31) walkCycleRight = 20;
                lastKey = KeyCode.D;

            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                spriteRenderer.sprite = sprites[walkCycleLeft];
                walkCycleLeft++;
                if (walkCycleLeft > 43) walkCycleLeft = 32;
                lastKey = KeyCode.A;

            }
            else
            {

                walkCycleDown = 0;
                walkCycleUp = 8;
                walkCycleRight = 20;
                walkCycleLeft = 32;
                if(lastKey==KeyCode.S)
                {
                    spriteRenderer.sprite = sprites[16];
                }
                else if(lastKey==KeyCode.W)
                {
                    spriteRenderer.sprite = sprites[17];
                }
                else if (lastKey == KeyCode.D)
                {
                    spriteRenderer.sprite = sprites[18];
                }
                else if (lastKey == KeyCode.A)
                {
                    spriteRenderer.sprite = sprites[19];
                }
                
            }
        }
        frame++;
    }


}
