using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSoundEffect : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip[] audioClipArray;
    public float timeBetweenShots = 2.0f;
    float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeBetweenShots)
        {
            if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.RightArrow)|| Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.DownArrow))
            {
                audioSource.PlayOneShot(RandomClip());
                timer = 0;
            }
        }
    }
    AudioClip RandomClip()
    {
        return audioClipArray[Random.Range(0, audioClipArray.Length-1)];
    }
}
