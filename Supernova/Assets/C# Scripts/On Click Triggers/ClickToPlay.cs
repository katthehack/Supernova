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
     SpriteRenderer button1;
     SpriteRenderer button2;
     SpriteRenderer button3;
    public AudioSource audioSource;
    public AudioClip[] audioOption;
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
            audioSource.PlayOneShot(audioOption[0]);
        }
        else if (Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (hover != 2) hover++;
            audioSource.PlayOneShot(audioOption[0]);
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
            if (hover == 0)
            {
                SceneManager.LoadScene("Tutorial-Outside");
                audioSource.PlayOneShot(audioOption[1]);
            }
            else if (hover == 1 && !controlsOpen)
            {
                animator.Play("controls open");

                //  animator.Play("controls open idle");
                controlsOpen = true;
                audioSource.PlayOneShot(audioOption[1]);
            }
            else if (hover == 1 && controlsOpen)
            {
                animator.Play("controls close");
                audioSource.PlayOneShot(audioOption[1]);

                //   animator.Play("controls");
                controlsOpen = false;
            }
            else if (hover == 2 && !openQuestion)
            {
                animatorAreYouSure.Play("are you sure open");
                openQuestion = true;
                audioSource.PlayOneShot(audioOption[0]);


            }
            
            
        }
        else if (hover == 2 && openQuestion)
        {


            if (Input.GetKeyDown(click)) //not working
            {
                Application.Quit();
                Debug.Log("application quit");
                audioSource.PlayOneShot(audioOption[1]);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                animatorAreYouSure.Play("are you sure close");
                openQuestion = false;
                audioSource.PlayOneShot(audioOption[0]);
            }
            
        }
    }
   
}
