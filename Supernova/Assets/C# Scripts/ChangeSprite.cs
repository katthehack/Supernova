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
    // Start is called before the first frame update
    void Start()
    {
        frame = 1;
        walkCycleUp = 7;
        walkCycleDown = 0;
    }
    // Update is called once per frame
    private void Update()
    {
        if (frame%25==0)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                spriteRenderer.sprite = sprites[walkCycleUp];
                walkCycleUp++;
                if (walkCycleUp > 13) walkCycleUp = 7;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                spriteRenderer.sprite = sprites[walkCycleDown];
                walkCycleDown++;
                if (walkCycleDown > 6) walkCycleDown = 0;

            }
        }
        frame++;
    }


}
