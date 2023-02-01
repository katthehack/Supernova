using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;


public class ChangeSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    int frame;
    // Start is called before the first frame update
    void Start()
    {
        frame = 1;
        Boolean doesLoop = true;
        while (doesLoop)
        {
            cycle();
        }
    }
    // Update is called once per frame

    void cycle()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            spriteRenderer.sprite = sprites[0];
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            spriteRenderer.sprite = sprites[frame];
            frame++;
            if (frame > 7) frame = 1;

        }
        // yield return new WaitForSeconds(0.111f);
    }

}
