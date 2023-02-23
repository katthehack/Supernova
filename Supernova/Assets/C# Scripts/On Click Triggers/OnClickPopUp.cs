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
    public void Start()
    {
        animator=GetComponent<Animator>();
        openOrClose= false; //false means closed
        popUpText.text = Dialog;
    }
    public void Update()
    {
        decor = GameObject.FindWithTag("Decor").GetComponent<BoxCollider2D>(); //decor-any object that will be interactible
        player = GameObject.FindWithTag("Player").GetComponent<BoxCollider2D>();
        Debug.Log("button clicked");
        if (decor.IsTouching(player)&&animator != null)
        {
            Debug.Log("collided");
            if(!openOrClose&&Input.GetKeyDown(KeyCode.E)) 
            {
                animator.SetTrigger("DialogueOpen");
                openOrClose= true;
                Debug.Log("open");
            }
            if (openOrClose&&Input.GetKeyDown(KeyCode.E))
            {
                animator.SetTrigger("DialogueClose");
                openOrClose= false;
                Debug.Log("close");
            }

        }

      

      //  back up plan uses this: if (collision.gameObject.tag == "Player") {}
      //requires passing in collision, which you cant do in an update function; would need button, so trying to avoid that here
    }
    
}
