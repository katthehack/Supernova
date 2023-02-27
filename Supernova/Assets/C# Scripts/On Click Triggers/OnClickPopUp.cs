using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnClickPopUp : MonoBehaviour
{
    // public GameObject popUpBox;
  //  public Rigidbody2D rb;
   public Animator animator;
     public TMP_Text popUpText;
 //   bool openOrClose;
    public string [] Dialog;
    public int repeats;
    public BoxCollider2D decor;
    public BoxCollider2D player;
    KeyCode input = KeyCode.E;
    public GameObject animObject;
    bool lastDialogue = false;
    public void Start()
    {
        animator=animObject.GetComponent<Animator>();
  //      openOrClose= animator.GetBool("OpenOrClose"); //false means closed
        repeats = 0;
    }
    public void Update()
    {
        animator.SetBool("EndOfDialogue", false);
            decor = GameObject.FindWithTag("Decor").GetComponent<BoxCollider2D>(); //decor-any object that will be interactible
            player = GameObject.FindWithTag("Player").GetComponent<BoxCollider2D>();
            if (decor.IsTouching(player) && animator != null)
            {
                Debug.Log("collided");
                if (repeats==0&&Input.GetKeyDown(input))
                {
                popUpText.text = Dialog[repeats];
                animator.Play("text box open");
                animator.SetTrigger("DialogueOpen");
                    animator.ResetTrigger("DialogueClose");
               //     openOrClose = true;
                    animator.SetBool("OpenOrClose", true); //bool not updating, open anim not playing while close plays
                animator.SetBool("EndOfDialogue", false);
                Debug.Log("open");
                    repeats++;
                }
                else if (repeats>0&&Input.GetKeyDown(input)&&!lastDialogue)
                {
                popUpText.text = Dialog[repeats];
                animator.SetTrigger("DialogueClose");
                    //  animator.ResetTrigger("DialogueOpen");
                 //   openOrClose = false;
                    animator.SetBool("OpenOrClose", false);
                    // animator.Play("text box close");
                    //  animator.Play("text box idle");
                    Debug.Log("close");
                //alt method is commented out
                if (repeats != Dialog.Length - 1) repeats++;
                else lastDialogue = true;
                
                }
            else if (Input.GetKeyDown(input)&&lastDialogue)
            {
                animator.SetTrigger("DialogueClose");
                 animator.ResetTrigger("DialogueOpen");
              //  openOrClose = false;
                animator.SetBool("OpenOrClose", false);
                animator.SetBool("EndOfDialogue", true);
                 animator.Play("text box close");
                 animator.Play("text box idle");
                Debug.Log("close");
                //alt method is commented out
                repeats=0;
                lastDialogue = false;
            }


            }

            
          

            //  back up plan uses this: if (collision.gameObject.tag == "Player") {}
            //requires passing in collision, which you cant do in an update function; would need button, so trying to avoid that here
        }

}
