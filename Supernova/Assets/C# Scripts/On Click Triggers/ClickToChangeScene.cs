using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToChangeScene : MonoBehaviour
{
    public Animator animator;
    public TMP_Text popUpText;
    public TMP_Text Names;
    public string[] Dialog;
    public string[] NameTag;
    public BoxCollider2D decor;
    public BoxCollider2D player;
    KeyCode input = KeyCode.E;
    KeyCode back = KeyCode.Q;
    public GameObject animObject;
    bool lastDialogue = false;
    public SpriteRenderer defaultSprite;
    public Sprite[] emotes;
    public WalkCycle walkCycle;
    // Start is called before the first frame update
    void Start()
    {
        animator = animObject.GetComponent<Animator>();
      //  walkCycle = GetComponent<WalkCycle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (decor.IsTouching(player) && animator != null && Dialog.Length == 1)
        {

            Debug.Log("collided");
            if (Input.GetKeyDown(input) && !lastDialogue)
            {
                popUpText.text = Dialog[0];
                defaultSprite.sprite = emotes[0];
                Names.text = NameTag[0];
                animator.Play("text box open");
                Debug.Log("open");
                lastDialogue = true;
                walkCycle.enabled = false;
            }

            else if (Input.GetKeyDown(input) && lastDialogue)
            {
                SceneManager.LoadScene("Tutorial-Inside");
                Debug.Log("next scene");
                lastDialogue = false;
                walkCycle.enabled = true;
                
            }
            else if (Input.GetKeyDown(back) && lastDialogue)
            {
                animator.Play("text box close");
                Debug.Log("close");
                lastDialogue = false;
                walkCycle.enabled = true;
            }


        }


    }
}
