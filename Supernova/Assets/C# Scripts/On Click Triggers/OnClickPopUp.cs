using System.Collections;
using System.Collections.Generic;
//using TMPro;
using UnityEngine;

public class OnClickPopUp : MonoBehaviour
{
    //public GameObject popUpBox;
   // public Animator animator;
   // public IMP_Text popUpText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            Debug.Log("gottem");
        }
    }
    /*
    public void PopUpText(string text)
    {
        popUpBox.SetActive(true);
        popUpText.text = text;
        animator.SetTrigger("pop");
    }
    */
}
