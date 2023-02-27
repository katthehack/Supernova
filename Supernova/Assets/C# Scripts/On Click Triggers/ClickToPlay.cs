using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToPlay : MonoBehaviour
{
    public Animator animator;
    KeyCode click = KeyCode.E;
    int hover;
    Boolean controlsOpen = false;
    private void Start()
    {
        hover= 0;
        animator.Play("controls");
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (hover != 0) hover--;
        }
        else if (Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (hover != 1) hover++;
        }

        if (Input.GetKeyDown(click))
        {
            if (hover == 0) SceneManager.LoadScene("Tutorial-Outside");
            else if (hover == 1&&!controlsOpen)
            {
                animator.Play("controls open");
               
              //  animator.Play("controls open idle");
                controlsOpen = true;
            }
            else if (hover == 1 && controlsOpen)
            {
                animator.Play("controls close");
              
             //   animator.Play("controls");
                controlsOpen = false;
            }
        }
    }
   
}
