using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnClickPopUp : MonoBehaviour
{
    // public GameObject popUpBox;
    public Rigidbody2D rb;
   public Animator animator;
     public TMP_Text popUpText;
    bool openOrClose;
    public string Dialog;
    public BoxCollider2D decor;
    public BoxCollider2D player;
    KeyCode input = KeyCode.E;
    public GameObject animObject;
    public void Start()
    {
        animator=animObject.GetComponent<Animator>();
        openOrClose= animator.GetBool("OpenOrClose"); //false means closed
        popUpText.text = Dialog;
    }
    public void Update()
    {
        
        decor = GameObject.FindWithTag("Decor").GetComponent<BoxCollider2D>(); //decor-any object that will be interactible
        player = GameObject.FindWithTag("Player").GetComponent<BoxCollider2D>();
        if (decor.IsTouching(player)&&animator != null)
        {
            Debug.Log("collided");
            if(!openOrClose&&Input.GetKeyDown(input)) 
            {
               // animator.Play("text box open");
                animator.SetTrigger("DialogueOpen");
                openOrClose= true;
                animator.SetBool("OpenOrClose",true); //bool not updating, open anim not playing while close plays
                
                Debug.Log("open");
            }
            else if (openOrClose&&Input.GetKeyDown(input))
            {
                animator.SetTrigger("DialogueClose");
                openOrClose= false;
                animator.SetBool("OpenOrClose", false);
               // animator.Play("text box close");
              //  animator.Play("text box idle");
                Debug.Log("close");
                //alt method is commented out
            }
        

        }

      

      //  back up plan uses this: if (collision.gameObject.tag == "Player") {}
      //requires passing in collision, which you cant do in an update function; would need button, so trying to avoid that here
    }
    
}
