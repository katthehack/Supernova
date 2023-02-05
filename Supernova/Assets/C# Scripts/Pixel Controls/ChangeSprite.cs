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
    int frame;
    //KeyCode lastKey;
    // Start is called before the first frame update
    void Start()
    {
        frame = 1;
        walkCycleUp = 8;
        walkCycleDown = 0;
    }
    // Update is called once per frame
    private void Update()
    {
        if (frame%25==0)
        {
           
            if (Input.GetKey(KeyCode.W))
            {
                spriteRenderer.sprite = sprites[walkCycleUp];
                walkCycleUp++;
               // lastKey = KeyCode.W;
                if (walkCycleUp > 15) walkCycleUp = 8;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                spriteRenderer.sprite = sprites[walkCycleDown];
                walkCycleDown++;
                if (walkCycleDown > 7) walkCycleDown = 0;
              //  lastKey= KeyCode.S;

            }
            else
            {
                walkCycleDown = 0;
                walkCycleUp = 8;
               /* if(lastKey==KeyCode.S)
                {
                    spriteRenderer.sprite = sprites[16];
                }
                else if(lastKey==KeyCode.W)
                {
                    spriteRenderer.sprite = sprites[17];
                }*/
                //18 (left) and 19 (right) will be added after
                //animations are created for left and right walk
            }
        }
        frame++;
    }


}
