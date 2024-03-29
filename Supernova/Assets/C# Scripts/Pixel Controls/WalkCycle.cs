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

    public AudioSource audioSource;
    public AudioClip[] audioClipArray;

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
        speed = 0.035f;
    }

    // Update is called once per frame
    void Update()
    {
        if (frame % 20==0)
        {
            if (Math.Abs(Input.GetAxis("Horizontal")) > Math.Abs(Input.GetAxis("Vertical"))) //x axis movement
            {
                move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
             //   if (frame % 24 == 0)
                {
                    if (Input.GetAxis("Horizontal") > 0)
                    {
                        if (walkCycle > 6) walkCycle = 0;
                        spriteRenderer.sprite = right[walkCycle];
                        walkCycle++;
                        lastKey = KeyCode.D;
                    }
                    else
                    {
                        if (walkCycle > 6) walkCycle = 0;
                        spriteRenderer.sprite = left[walkCycle];
                        walkCycle++;
                        lastKey = KeyCode.A;
                    }
                    if (walkCycle == 3 || walkCycle == 6) //play sound when character's foot is placed down
                    {
                        audioSource.PlayOneShot(RandomClip());
                    }
                }
            }
            else if (Math.Abs(Input.GetAxis("Vertical")) > Math.Abs(Input.GetAxis("Horizontal")))//y axis movement
            {
                move = new Vector3(0, Input.GetAxis("Vertical"), 0);
             //   if (frame % 24 == 0)
                {
                    if (Input.GetAxis("Vertical") > 0)
                    {
                        if (walkCycle > 7) walkCycle = 0;
                        spriteRenderer.sprite = up[walkCycle];
                        walkCycle++;
                        lastKey = KeyCode.W;
                    }
                    else
                    {
                        if (walkCycle > 7) walkCycle = 0;
                        spriteRenderer.sprite = down[walkCycle];
                        walkCycle++;
                        lastKey = KeyCode.S;
                    }
                }
                if (walkCycle == 3 || walkCycle == 6)
                {
                    audioSource.PlayOneShot(RandomClip());
                }
            }
            else
            {
                move = new Vector3(0, 0, 0);
            //    if (frame % 24 == 0)
                {
                    walkCycle = 0;
                    if (lastKey == KeyCode.S)
                    {
                        spriteRenderer.sprite = down[7];
                    }
                    else if (lastKey == KeyCode.W)
                    {
                        spriteRenderer.sprite = up[7];
                    }
                    else if (lastKey == KeyCode.D)
                    {
                        spriteRenderer.sprite = right[0];
                    }
                    else if (lastKey == KeyCode.A)
                    {
                        spriteRenderer.sprite = left[0];
                    }
                }
            }
        }
        transform.position += move * speed;
        frame++; 
    }
    AudioClip RandomClip()
    {
        return audioClipArray[UnityEngine.Random.Range(0, audioClipArray.Length - 1)];
    }
}