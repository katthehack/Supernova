using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;


public class ChangeSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            spriteRenderer.sprite = sprites[0];
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            spriteRenderer.sprite = sprites[1];
        }
    }
    
}
