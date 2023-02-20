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
    public void Start()
    {
        animator=GetComponent<Animator>();
        openOrClose= false; //false means closed
        popUpText.text = Dialog;
    }
    
   public void Update()
    {
        if (animator != null)
        {
            if(!openOrClose&&Input.GetKeyDown(KeyCode.Space)) 
            {
                animator.SetTrigger("DialogueOpen");
                openOrClose= true;
            }
            if (openOrClose&&Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("DialogueClose");
                openOrClose= false;
            }

        }

      

      //  add in if (collision.gameObject.tag == "Player") {}
    }
    
}
