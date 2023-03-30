using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class EnemyCombat : MonoBehaviour
{
    public CombatInventory combatInventory;
    public EnemyCombat enemyCombat;
    public PlayerCombat playerCombat;
    Random rnd = new Random();
    Boolean attackBuffed;

    private void Start()
    {
        combatInventory=gameObject.GetComponent<CombatInventory>();
        enemyCombat=gameObject.GetComponent<EnemyCombat>();
        playerCombat=gameObject.GetComponent<PlayerCombat>();
        combatInventory.playerTurn = true;
        attackBuffed = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(!combatInventory.playerTurn)
        {
            int abilUsed = rnd.Next(1,combatInventory.prob1+ combatInventory.prob2+ combatInventory.prob3 + combatInventory.prob4+1); //+1 to include upper bound
            int charAttacked = rnd.Next(1,combatInventory.solHealth+combatInventory.astrumHealth+combatInventory.allyHealth+1); //lower bound is 1 and not 0 to prevent player from being attacked when health is 0 (line 31)
            Debug.Log("abil used-" + abilUsed + " charAttacked-"+charAttacked);
            //for lowest health gets highest chance-make all health 10-health to flip the #s
            if (abilUsed<=combatInventory.prob1)
            {
                if (charAttacked <= combatInventory.solHealth)
                {
                    switch (combatInventory.enemyAbil1Type)
                    {
                        case 4:
                            if (attackBuffed)
                            {
                                combatInventory.solHealth -= combatInventory.enemyAbil1Damage * 2;
                                attackBuffed = false;
                            }
                            else combatInventory.solHealth -= combatInventory.enemyAbil1Damage;
                            break;
                        case 0:
                            combatInventory.enemyHealth += combatInventory.enemyAbil1Damage;
                            break;
                        case 3:
                            combatInventory.solStunned = true;
                            combatInventory.allyHealth -= combatInventory.enemyAbil3Damage;
                            break;
                        case 1:
                            combatInventory.enemyShield = true;
                            break;
                        case 2:
                            attackBuffed = true;
                            break;
                        default: //temporary
                            combatInventory.solHealth -= combatInventory.enemyAbil1Damage;
                            break;
                    }
                }
                else if (charAttacked <= combatInventory.solHealth + combatInventory.astrumHealth && charAttacked > combatInventory.solHealth)
                {
                    switch (combatInventory.enemyAbil1Type)
                    {
                        case 4:
                            if (attackBuffed)
                            {
                                combatInventory.astrumHealth -= combatInventory.enemyAbil1Damage * 2;
                                attackBuffed = false;
                            }
                            else combatInventory.astrumHealth -= combatInventory.enemyAbil1Damage;
                            break;
                        case 0:
                            combatInventory.enemyHealth += combatInventory.enemyAbil1Damage;
                            break;
                        case 3:
                            combatInventory.allyHealth -= combatInventory.enemyAbil3Damage;
                            combatInventory.astrumStunned = true;
                            break;
                        case 1:
                            combatInventory.enemyShield = true;
                            break;
                        case 2:
                            attackBuffed = true;
                            break;
                        default: //temporary
                            combatInventory.astrumHealth -= combatInventory.enemyAbil1Damage;
                            break;
                    }
                }
                else
                {
                    switch (combatInventory.enemyAbil1Type)
                    {
                        case 4:
                            if (attackBuffed)
                            {
                                combatInventory.allyHealth -= combatInventory.enemyAbil1Damage * 2;
                                attackBuffed = false;
                            }
                            else combatInventory.allyHealth -= combatInventory.enemyAbil1Damage;
                            break;
                        case 0:
                            combatInventory.enemyHealth += combatInventory.enemyAbil1Damage;
                            break;
                        case 3:
                            combatInventory.allyStunned = true;
                            combatInventory.allyHealth -= combatInventory.enemyAbil3Damage;
                            break;
                        case 1:
                            combatInventory.enemyShield = true;
                            break;
                        case 2:
                            attackBuffed = true;
                            break;
                        default: //temporary
                            combatInventory.allyHealth -= combatInventory.enemyAbil1Damage;
                            break;
                    }
                }
                Debug.Log("1st abil-charAttacked = "+charAttacked);
                combatInventory.prob1 = 1;
                combatInventory.prob2++;
                combatInventory.prob3++;
                combatInventory.prob4++;
            }
            else if(abilUsed<=(combatInventory.prob1+combatInventory.prob2)&&abilUsed>combatInventory.prob1) //2nd abil
            {
                if (charAttacked <= combatInventory.solHealth) //sol attacked
                {
                    switch (combatInventory.enemyAbil2Type)
                    {
                        case 4:
                            if (attackBuffed)
                            {
                                combatInventory.solHealth -= combatInventory.enemyAbil2Damage * 2;
                                attackBuffed = false;
                            }
                            else combatInventory.solHealth -= combatInventory.enemyAbil2Damage; 
                            break;
                        case 0:
                            combatInventory.enemyHealth += combatInventory.enemyAbil2Damage;
                            break;
                        case 3:
                            combatInventory.solStunned = true;
                            combatInventory.allyHealth -= combatInventory.enemyAbil3Damage;
                            break;
                        case 1:
                            combatInventory.enemyShield = true;
                            break;
                        case 2:
                            attackBuffed = true;
                            break;
                        default: //temporary
                            combatInventory.solHealth -= combatInventory.enemyAbil2Damage;
                            break;
                    }
                }
                else if (charAttacked <= combatInventory.solHealth + combatInventory.astrumHealth && charAttacked > combatInventory.solHealth) //astrum attacked
                {
                    switch (combatInventory.enemyAbil2Type)
                    {
                        case 4:
                            if (attackBuffed)
                            {
                                combatInventory.astrumHealth -= combatInventory.enemyAbil2Damage * 2;
                                attackBuffed = false;
                            }
                            else combatInventory.astrumHealth -= combatInventory.enemyAbil2Damage;
                            break;
                        case 0:
                            combatInventory.enemyHealth += combatInventory.enemyAbil2Damage;
                            break;
                        case 3:
                            combatInventory.astrumStunned = true;
                            combatInventory.allyHealth -= combatInventory.enemyAbil3Damage;
                            break;
                        case 1:
                            combatInventory.enemyShield = true;
                            break;
                        case 2:
                            attackBuffed = true;
                            break;
                        default: //temporary
                            combatInventory.astrumHealth -= combatInventory.enemyAbil2Damage;
                            break;
                    }
                }
                else //ally attacked
                {
                    switch (combatInventory.enemyAbil2Type)
                    {
                        case 4:
                            if (attackBuffed)
                            {
                                combatInventory.allyHealth -= combatInventory.enemyAbil2Damage * 2;
                                attackBuffed = false;
                            }
                            else combatInventory.allyHealth -= combatInventory.enemyAbil2Damage;
                            break;
                        case 0:
                            combatInventory.enemyHealth += combatInventory.enemyAbil2Damage;
                            break;
                        case 3:
                            combatInventory.allyStunned = true;
                            combatInventory.allyHealth -= combatInventory.enemyAbil3Damage;
                            break;
                        case 1:
                            combatInventory.enemyShield = true;
                            break;
                        case 2:
                            attackBuffed = true;
                            break;
                        default: //temporary
                            combatInventory.allyHealth -= combatInventory.enemyAbil2Damage;
                            break;
                    }
                }
                Debug.Log("2nd abil-charAttacked = "+charAttacked);
                combatInventory.prob1++;
                combatInventory.prob2=1;
                combatInventory.prob3++;
                combatInventory.prob4++;
            }
            else if (abilUsed <= (combatInventory.prob1 + combatInventory.prob2+combatInventory.prob3) && abilUsed > combatInventory.prob2)
            {
                if (charAttacked <= combatInventory.solHealth)
                {
                    switch (combatInventory.enemyAbil3Type)
                    {
                        case 4:
                            if (attackBuffed)
                            {
                                combatInventory.solHealth -= combatInventory.enemyAbil3Damage * 2;
                                attackBuffed = false;
                            }
                            else combatInventory.solHealth -= combatInventory.enemyAbil3Damage;
                            break;
                        case 0:
                            combatInventory.enemyHealth += combatInventory.enemyAbil3Damage;
                            break;
                        case 3:
                            combatInventory.solStunned = true;
                            combatInventory.allyHealth -= combatInventory.enemyAbil3Damage;
                            break;
                        case 1:
                            combatInventory.enemyShield = true;
                            break;
                        case 2:
                            attackBuffed = true;
                            break;
                        default: //temporary
                            combatInventory.solHealth -= combatInventory.enemyAbil3Damage;
                            break;
                    }
                }
                else if (charAttacked <= combatInventory.solHealth + combatInventory.astrumHealth && charAttacked > combatInventory.solHealth)
                {
                    switch (combatInventory.enemyAbil3Type)
                    {
                        case 4:
                            if (attackBuffed)
                            {
                                combatInventory.astrumHealth -= combatInventory.enemyAbil3Damage * 2;
                                attackBuffed = false;
                            }
                            else combatInventory.astrumHealth -= combatInventory.enemyAbil3Damage;
                            break;
                        case 0:
                            combatInventory.enemyHealth += combatInventory.enemyAbil3Damage;
                            break;
                        case 3:
                            combatInventory.astrumStunned = true;
                            combatInventory.allyHealth -= combatInventory.enemyAbil3Damage;
                            break;
                        case 1:
                            combatInventory.enemyShield = true;
                            break;
                        case 2:
                            attackBuffed = true;
                            break;
                        default: //temporary
                            combatInventory.astrumHealth -= combatInventory.enemyAbil3Damage;
                            break;
                    }
                }
                else
                {
                    switch (combatInventory.enemyAbil3Type)
                    {
                        case 4:
                            if (attackBuffed)
                            {
                                combatInventory.allyHealth -= combatInventory.enemyAbil3Damage * 2;
                                attackBuffed = false;
                            }
                            else combatInventory.allyHealth -= combatInventory.enemyAbil3Damage;
                            break;
                        case 0:
                            combatInventory.enemyHealth += combatInventory.enemyAbil3Damage;
                            break;
                        case 3:
                            combatInventory.allyStunned = true;
                            combatInventory.allyHealth-=combatInventory.enemyAbil3Damage;
                            break;
                        case 1:
                            combatInventory.enemyShield = true;
                            break;
                        case 2:
                            attackBuffed = true;
                            break;
                        default: //temporary
                            combatInventory.allyHealth -= combatInventory.enemyAbil3Damage;
                            break;
                    }
                }
                Debug.Log("3rd abil-charAttacked = " + charAttacked);
                combatInventory.prob1++; 
                combatInventory.prob2++;
                combatInventory.prob3=1;
                combatInventory.prob4++;
            }
            else 
            {
                Debug.Log("4th abil");
                combatInventory.prob1++;
                combatInventory.prob2++;
                combatInventory.prob3++;
                combatInventory.prob4 = 1;
            }
            combatInventory.playerTurn = true;
            combatInventory.rounds++;
        }

    }

}
