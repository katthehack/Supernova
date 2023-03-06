using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToPlay : MonoBehaviour
{
    public Animator animator;
    public Animator animatorAreYouSure;
    KeyCode click = KeyCode.E;
    Boolean openQuestion;
    int hover;
    Boolean controlsOpen = false;
    public Color hoverTint;
    public Color regular;
    public SpriteRenderer button1;
    public SpriteRenderer button2;
    public SpriteRenderer button3;
    private void Start()
    {
        hover= 0;
        animator.Play("controls");
        openQuestion = false;
        button1 = GameObject.Find("Start Button").GetComponent<SpriteRenderer>();
        button2 = GameObject.Find("Controls Button").GetComponent<SpriteRenderer>();
        button3 = GameObject.Find("Exit Game Button").GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (hover != 0) hover--;
        }
        else if (Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (hover != 2) hover++;
        }
        if (openQuestion) hover = 2;
        else if (controlsOpen) hover = 1;
        if (hover == 0)
        {
            button1.color = hoverTint;
            button2.color = regular;
        }
        if(hover == 1)
        {
            button2.color = hoverTint;
            button1.color = regular;
            button3.color = regular;
        }
        if(hover == 2)
        {
            button3.color = hoverTint;
            button2.color = regular;
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
            else if (hover == 2&&!openQuestion)
            {
                animatorAreYouSure.Play("are you sure open");
                openQuestion = true;
                
               
            }
            
            
        }
        else if (hover == 2 && openQuestion)
        {


            if (Input.GetKeyDown(click)) //not working
            {
                Application.Quit();
                Debug.Log("application quit");
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                animatorAreYouSure.Play("are you sure close");
                openQuestion = false;
            }
            
        }
    }
   
}
