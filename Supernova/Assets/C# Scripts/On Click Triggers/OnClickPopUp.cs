using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnClickPopUp : MonoBehaviour
{
    public GameObject popUpBox;
   public Animator animator;
    public TMP_Text popUpText;
    public void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            Debug.Log("gottem");
            animator.SetTrigger("Trigger");
        }
    }
    
    public void PopUpText(string text)
    {
        popUpBox.SetActive(true);
        popUpText.text = text;
        //animator.SetTrigger("open");
    }
    
}
