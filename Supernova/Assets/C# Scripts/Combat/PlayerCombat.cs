using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour
{
    public CombatInventory combatInventory;
    public EnemyCombat enemyCombat;
    public PlayerCombat playerCombat;
    int characterSelect;
    int abilitySelect;
    int typeSelect;
    SpriteRenderer solBox;
    SpriteRenderer astrumBox;
    SpriteRenderer allyBox;
    public Sprite[] frame;
    public AudioSource audioSource;
    public AudioClip[] audioOption;
    KeyCode input = KeyCode.E;
    KeyCode back = KeyCode.Q;
    int fontSize, fontHoverSize;
    Boolean sol, astrum, ally, powers,action,item;
    public TMP_Text Ability1, Ability2, Ability3, Ability4; //displays abilities text
    Boolean solSelect, astrumSelect, allySelect; //has player selected an attack for them yet
    int solSelectAbil, astrumSelectAbil, allySelectAbil; //which abil 1-4 is activated
    public TMP_Text astrumHealth, solHealth, allyHealth, enemyHealth, roundsDisplay; //displays health

    private void Start()
    {
        combatInventory = gameObject.GetComponent<CombatInventory>();
        enemyCombat = gameObject.GetComponent<EnemyCombat>();
        playerCombat = gameObject.GetComponent<PlayerCombat>();
        characterSelect = abilitySelect=0; //position of mouse
        solBox = GameObject.Find("Sol box").GetComponent<SpriteRenderer>();
        astrumBox = GameObject.Find("Astrum box").GetComponent<SpriteRenderer>();
        allyBox = GameObject.Find("Ally box").GetComponent<SpriteRenderer>();
        sol = astrum = ally = powers = false; //where user is hovering in powers
        fontSize = 25;
        fontHoverSize = 30;
        solSelect=astrumSelect= allySelect =action = item=false; //have you selected an ability for them yet
        solSelectAbil = astrumSelectAbil = allySelectAbil = 0; //determines which attack is used
        typeSelect = 0;
        Ability1.text = "Attack";
        Ability2.text = "Item";
        Ability3.text = "Block";
        Ability4.text = "Run";
    }
    // Update is called once per frame
    void Update()
    {
        solHealth.text = combatInventory.solHealth.ToString();
        astrumHealth.text = combatInventory.astrumHealth.ToString();
        allyHealth.text = combatInventory.allyHealth.ToString();
        enemyHealth.text = combatInventory.enemyHealth.ToString();
        roundsDisplay.text = "Round "+combatInventory.rounds.ToString();
        if (!powers) //character select window
        {
            Ability1.fontSize = fontSize;
            Ability2.fontSize = fontSize;
            Ability3.fontSize = fontSize;
            Ability4.fontSize = fontSize;
            Ability1.text = "Attack";
            Ability2.text = "Item";
            Ability3.text = "Block";
            Ability4.text = "Run";
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (characterSelect != 0) characterSelect--;
                audioSource.PlayOneShot(audioOption[0]);
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (characterSelect != 2) characterSelect++;
                audioSource.PlayOneShot(audioOption[0]);
            }

            if (characterSelect == 0)
            {
                solBox.sprite = frame[0];
                astrumBox.sprite = frame[4];
                
            }
            else if (characterSelect == 1)
            {
                astrumBox.sprite = frame[1];
                solBox.sprite = frame[3];
                allyBox.sprite = frame[5];

            }
            else if (characterSelect == 2)
            {
                allyBox.sprite = frame[2];
                astrumBox.sprite = frame[4];

            }

            if (combatInventory.playerTurn && Input.GetKeyDown(input))
            {
                if (characterSelect == 0) sol = true;
                else if (characterSelect == 1) astrum = true;
                else if (characterSelect == 2) ally = true;
                action = true;
                powers = true;
                abilitySelect = 0;
                typeSelect = 0;
                audioSource.PlayOneShot(audioOption[1]);

            }
        }

        else if (action) //action selecter-fight,item,block,run
        {
            Ability1.text = "Attack";
            Ability2.text = "Item";
            Ability3.text = "Block";
            Ability4.text = "Run";
            if (Input.GetKeyDown(input))
            {
                action = false;
                audioSource.PlayOneShot(audioOption[1]);
                if (typeSelect == 0) //attack
                {
                    powers = true;

                    if (characterSelect==0)
                    {
                        Ability1.text = combatInventory.solAbil1;
                        Ability2.text = combatInventory.solAbil2;
                        Ability3.text = combatInventory.solAbil3;
                        Ability4.text = combatInventory.solAbil4;
                    }
                    else if (characterSelect == 1)
                    {
                        Ability1.text = combatInventory.astrumAbil1;
                        Ability2.text = combatInventory.astrumAbil2;
                        Ability3.text = combatInventory.astrumAbil3;
                        Ability4.text = combatInventory.astrumAbil4;
                    }
                    else if (characterSelect == 2) {
                        Ability1.text = combatInventory.allyAbil1;
                        Ability2.text = combatInventory.allyAbil2;
                        Ability3.text = combatInventory.allyAbil3;
                        Ability4.text = combatInventory.allyAbil4;
                    }
                }
                else if (typeSelect == 1) //item
                {
                    item = true;
                    Ability1.text = combatInventory.item1;
                    Ability2.text = combatInventory.item2;
                    Ability3.text = combatInventory.item3;
                    Ability4.text = combatInventory.item4;


                }
                else if (typeSelect == 2) //block
                {
                    if(sol)
                    {
                        solSelectAbil = abilitySelect;
                        solSelect = true;
                        sol = astrum = ally = powers = false;
                        audioSource.PlayOneShot(audioOption[1]);
                    }
                    else if (astrum)
                    {
                        astrumSelectAbil = abilitySelect;
                        astrumSelect = true;
                        sol = astrum = ally = powers = false;
                        audioSource.PlayOneShot(audioOption[1]);
                    }
                    else if (ally)
                    {
                        allySelectAbil = abilitySelect;
                        allySelect = true;
                        sol = astrum = ally = powers = false;
                        audioSource.PlayOneShot(audioOption[1]);
                    }

                }
                else if (typeSelect == 3) //run
                {
                    SceneManager.LoadScene("Tutorial-Inside");
                    audioSource.PlayOneShot(audioOption[1]);
                }
            }
            if(Input.GetKeyDown(KeyCode.D)) 
            {
                if (typeSelect < 3) typeSelect++;
                audioSource.PlayOneShot(audioOption[0]);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                if (typeSelect > 0) typeSelect--;
                audioSource.PlayOneShot(audioOption[0]);
            }
            if(typeSelect==0)
            {
                Ability1.fontSize = fontHoverSize;
                Ability2.fontSize = fontSize;
            }
            else if(typeSelect==1)
            {
                Ability2.fontSize = fontHoverSize;
                Ability1.fontSize = fontSize;
                Ability3.fontSize = fontSize;
            }
            else if(typeSelect==2)
            {
                Ability3.fontSize = fontHoverSize;
                Ability2.fontSize = fontSize;
                Ability4.fontSize = fontSize;
            }
            else if (typeSelect==3)
            {
                Ability4.fontSize = fontHoverSize;
                Ability3.fontSize = fontSize;
            }
            if(Input.GetKeyDown(back))//if you press q from item menu text doesnt revert
            {
                action = false;
                sol = astrum = ally = powers = false;
                audioSource.PlayOneShot(audioOption[1]);
                
            }
        }
        else if(powers)//attacking window
        {
            
            if(sol && Input.GetKeyDown(input)) //ability selected
            {
                solSelectAbil = abilitySelect;
                solSelect = true;
                sol=astrum=ally=powers = false;
                audioSource.PlayOneShot(audioOption[1]);
            }
            else if (astrum && Input.GetKeyDown(input))
            {
                astrumSelectAbil = abilitySelect;
                astrumSelect = true;
                sol = astrum = ally = powers = false;
                audioSource.PlayOneShot(audioOption[1]);
            }
            else if (ally && Input.GetKeyDown(input))
            {
                allySelectAbil = abilitySelect;
                allySelect = true;
                sol = astrum = ally = powers = false;
                audioSource.PlayOneShot(audioOption[1]);
            }
            else if (Input.GetKeyDown(back)) 
            {
                action = true;
                audioSource.PlayOneShot(audioOption[1]);

            }

            if(Input.GetKeyDown(KeyCode.D)) //scroll through abil window
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

        if(solSelect&&allySelect&&astrumSelect)
        {

        }
        /*
        if (combatInventory.playerTurn && Input.GetKeyDown(input))
        {
            combatInventory.enemyHealth--;
            combatInventory.playerTurn = false;
        }
        */


     /*   if (combatInventory.solHealth == 0 && combatInventory.astrumHealth == 0 && combatInventory.allyHealth == 0) //end game
        {
            SceneManager.LoadScene("Tutorial-Inside");
        }
        else if (combatInventory.enemyHealth == 0)
        {

        }
     */
    }
}
