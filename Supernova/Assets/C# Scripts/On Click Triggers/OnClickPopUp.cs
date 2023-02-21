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
    public BoxCollider2D player; //finish this
    public void Start()
    {
        animator=GetComponent<Animator>();
        openOrClose= false; //false means closed
        popUpText.text = Dialog;
    }
    public void Update()
    {
        
    }
    public void TextBoxStatus(Collision collision)
    {
        //object = GameObject.FindWithTag("Player").GetComponent<Collider2D>();
        Debug.Log("button clicked");
        if (collision.gameObject.tag == "Player"&&animator != null)
        {
            Debug.Log("collided");
            if(!openOrClose&&Input.GetKeyDown(KeyCode.Space)) 
            {
                animator.SetTrigger("DialogueOpen");
                openOrClose= true;
                Debug.Log("open");
            }
            if (openOrClose&&Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("DialogueClose");
                openOrClose= false;
                Debug.Log("close");
            }

        }

      

      //  add in if (collision.gameObject.tag == "Player") {}
    }
    
}
