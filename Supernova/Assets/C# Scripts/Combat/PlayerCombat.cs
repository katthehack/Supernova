using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCombat : MonoBehaviour
{
    public CombatInventory combatInventory;
    public EnemyCombat enemyCombat;
    public PlayerCombat playerCombat;
    int characterSelect;
    int abilitySelect;
    SpriteRenderer solBox;
    SpriteRenderer astrumBox;
    SpriteRenderer allyBox;
    public Sprite[] frame;
    public AudioSource audioSource;
    public AudioClip[] audioOption;
    KeyCode input = KeyCode.E;
    KeyCode back = KeyCode.Q;
    int fontSize, fontHoverSize;
    Boolean sol, astrum, ally, powers;
    public TMP_Text Ability1, Ability2, Ability3, Ability4;

    private void Start()
    {
        combatInventory = gameObject.GetComponent<CombatInventory>();
        enemyCombat = gameObject.GetComponent<EnemyCombat>();
        playerCombat = gameObject.GetComponent<PlayerCombat>();
        characterSelect = abilitySelect=0;
        solBox = GameObject.Find("Sol box").GetComponent<SpriteRenderer>();
        astrumBox = GameObject.Find("Astrum box").GetComponent<SpriteRenderer>();
        allyBox = GameObject.Find("Ally box").GetComponent<SpriteRenderer>();
        sol = astrum = ally = powers = false;
        fontSize = 22;
        fontHoverSize = 28;
    }
    // Update is called once per frame
    void Update()
    {
        if (!powers) //character select window
        {
            Ability1.fontSize = fontSize;
            Ability2.fontSize = fontSize;
            Ability3.fontSize = fontSize;
            Ability4.fontSize = fontSize;
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (characterSelect != 0) characterSelect--;
                audioSource.PlayOneShot(audioOption[0]);
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (characterSelect != 2) characterSelect++;
                audioSource.PlayOneShot(audioOption[0]);
            }

            if (characterSelect == 0)
            {
                solBox.sprite = frame[0];
                astrumBox.sprite = frame[4];
                Ability1.text = combatInventory.solAbil1;
                Ability2.text = combatInventory.solAbil2;
                Ability3.text = combatInventory.solAbil3;
                Ability4.text = combatInventory.solAbil4;
            }
            else if (characterSelect == 1)
            {
                astrumBox.sprite = frame[1];
                solBox.sprite = frame[3];
                allyBox.sprite = frame[5];
                Ability1.text = combatInventory.astrumAbil1;
                Ability2.text = combatInventory.astrumAbil2;
                Ability3.text = combatInventory.astrumAbil3;
                Ability4.text = combatInventory.astrumAbil4;
            }
            else if (characterSelect == 2)
            {
                allyBox.sprite = frame[2];
                astrumBox.sprite = frame[4];
                Ability1.text = combatInventory.allyAbil1;
                Ability2.text = combatInventory.allyAbil2;
                Ability3.text = combatInventory.allyAbil3;
                Ability4.text = combatInventory.allyAbil4;
            }

            if (combatInventory.playerTurn && Input.GetKeyDown(input))
            {
                if (characterSelect == 0) sol = true;
                else if (characterSelect == 1) astrum = true;
                else if (characterSelect == 2) ally = true;
                powers = true;
                abilitySelect = 0;
                audioSource.PlayOneShot(audioOption[1]);
            }
        }

        else //powers window
        {
            
            if(sol && Input.GetKeyDown(input)) //individial abilities-determines what is shown and available to click for the user
            {

            }
            else if (astrum && Input.GetKeyDown(input))
            {

            }
            else if (ally && Input.GetKeyDown(input))
            {

            }
            else if (Input.GetKeyDown(back)) 
            {
                sol = astrum = ally = powers = false;
                audioSource.PlayOneShot(audioOption[1]);

            }

            if(Input.GetKeyDown(KeyCode.D))
            {
                if (abilitySelect < 3) abilitySelect++;
                audioSource.PlayOneShot(audioOption[0]);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                if (abilitySelect > 0) abilitySelect--;
                audioSource.PlayOneShot(audioOption[0]);
            }

            if(abilitySelect== 0) 
            {
                Ability1.fontSize = fontHoverSize;
                Ability2.fontSize = fontSize;
            }
           else if (abilitySelect == 1)
            {
                Ability2.fontSize =fontHoverSize;
                Ability1.fontSize = fontSize;
                Ability3.fontSize = fontSize;
            }
            else if (abilitySelect == 2)
            {
                Ability3.fontSize = fontHoverSize;
                Ability2.fontSize = fontSize;
                Ability4.fontSize = fontSize;
            }
            else if (abilitySelect == 3)
            {
                Ability4.fontSize = fontHoverSize;
                Ability3.fontSize = fontSize;
            }
        }


        /*
        if (combatInventory.playerTurn && Input.GetKeyDown(input))
        {
            combatInventory.enemyHealth--;
            combatInventory.playerTurn = false;
        }
        */


        if (combatInventory.playerHealth == 0)
        {
            SceneManager.LoadScene("");
        }
        else if (combatInventory.enemyHealth == 0)
        {

        }
    }
}
