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
    public void Start()
    {
        animator=animObject.GetComponent<Animator>();
  
        repeats = 0;
    }
    public void Update()
    {
       
            decor = GameObject.FindWithTag("Decor").GetComponent<BoxCollider2D>(); //decor-any object that will be interactible
            player = GameObject.FindWithTag("Player").GetComponent<BoxCollider2D>();
            if (decor.IsTouching(player) && animator != null&&Dialog.Length>1)
            {
            
                Debug.Log("collided");
                if (repeats==0&&Input.GetKeyDown(input))
                {
                popUpText.text = Dialog[repeats];
                defaultSprite.sprite = emotes[repeats];
                Names.text = NameTag[repeats];
                animator.Play("text box open");
               
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
                animator.Play("text box open");
                Debug.Log("open");
                lastDialogue = true;
            }
           
            else if (Input.GetKeyDown(input) && lastDialogue)
            {
                animator.Play("text box close");
                Debug.Log("close");
                repeats = 0;
                lastDialogue = false;
            }


        }

    }

}
