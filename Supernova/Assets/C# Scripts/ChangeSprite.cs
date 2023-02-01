using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;


public class ChangeSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    int walkCycle;
    int frame;
    // Start is called before the first frame update
    void Start()
    {
        frame = 1;
        walkCycle = 1;
    }
    // Update is called once per frame
    private void Update()
    {
        if (frame%10==1)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                spriteRenderer.sprite = sprites[0];
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                spriteRenderer.sprite = sprites[walkCycle];
                walkCycle++;
                if (walkCycle > 7) walkCycle = 1;

            }
        }
        frame++;
    }


}
