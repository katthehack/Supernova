using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OnClickPopUp : MonoBehaviour
{
  
   public Animator animator;
    public TMP_Text popUpText;
    public TMP_Text Names;
    public string [] Dialog;
    public string[] NameTag;
    public int repeats;
    public BoxCollider2D decor;
    public BoxCollider2D player;
    KeyCode input = KeyCode.E;
    public GameObject animObject;
    bool lastDialogue = false;
    public SpriteRenderer defaultSprite;
    public Sprite[] emotes;
    public WalkCycle walkCycle;
    public AudioSource audioSource;
    public AudioClip[] audioClipArray;
    public void Start()
    {
        animator=animObject.GetComponent<Animator>();
  
        repeats = 0;
    }
    public void Update()
    {
            if (decor.IsTouching(player) && animator != null&&Dialog.Length>1)
            {
            
                Debug.Log("collided");
            if (repeats == 0 && Input.GetKeyDown(input))
            {
                popUpText.text = Dialog[repeats];
                defaultSprite.sprite = emotes[repeats];
                Names.text = NameTag[repeats];
                animator.Play("text box open");
                walkCycle.enabled = false;
                audioSource.PlayOneShot(audioClipArray[repeats]);

                repeats++;
                }
                else if (repeats>0&&Input.GetKeyDown(input)&&!lastDialogue)
                {
                popUpText.text = Dialog[repeats];
              
                if (repeats != Dialog.Length - 1) repeats++;
                else lastDialogue = true;
                
                }
                else if (Input.GetKeyDown(input)&&lastDialogue)
                {
                     animator.Play("text box close");
                    Debug.Log("close");
                    repeats=0;
                    lastDialogue = false;
                walkCycle.enabled = true;
                }


            }

        else if (decor.IsTouching(player) && animator != null && Dialog.Length ==1)
        {

            Debug.Log("collided");
            if (Input.GetKeyDown(input)&&!lastDialogue)
            {
                popUpText.text = Dialog[repeats];
                defaultSprite.sprite = emotes[repeats];
                Names.text = NameTag[repeats];
                audioSource.PlayOneShot(audioClipArray[repeats]);
                animator.Play("text box open");
                Debug.Log("open");
                lastDialogue = true;
                walkCycle.enabled = false;
            }
           
            else if (Input.GetKeyDown(input) && lastDialogue)
            {
                animator.Play("text box close");
                Debug.Log("close");
                repeats = 0;
                lastDialogue = false;
                walkCycle.enabled = true;
            }


        }

    }

}
