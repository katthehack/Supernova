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
            int charAttacked = rnd.Next(1,45-(combatInventory.solHealth+combatInventory.astrumHealth+combatInventory.allyHealth)+1); //lower bound is 1 and not 0 to prevent player from being attacked when health is 0 (line 31)
            Debug.Log("charAttacked-"+charAttacked);
            //for lowest health gets highest chance-make all health 10-health to flip the #s
            if (abilUsed<=combatInventory.prob1) //first ability used
            {
                if (charAttacked <= 15-combatInventory.solHealth) //sol attacked with first abil
                {
                    switch (combatInventory.enemyAbil1Type)
                    {
                        case 4: //attack
                            if (attackBuffed)
                            {
                                combatInventory.solHealth -= combatInventory.enemyAbil1Damage * 2;
                                attackBuffed = false;
                            }
                            else combatInventory.solHealth -= combatInventory.enemyAbil1Damage;
                            break;
                        case 0: //heal
                            combatInventory.enemyHealth += combatInventory.enemyAbil1Damage;
                            break;
                        case 3: //stun
                            combatInventory.solStunned = true;
                            combatInventory.solHealth -= combatInventory.enemyAbil1Damage;
                            break;
                        case 1: //shield
                            combatInventory.enemyShield = true;
                            break;
                        case 2: //attack buff
                            if(attackBuffed)
                            {
                                if (combatInventory.enemyAbil1Type == 4) combatInventory.solHealth -= combatInventory.enemyAbil1Damage * 2;
                                else if (combatInventory.enemyAbil2Type == 4) combatInventory.solHealth -= combatInventory.enemyAbil2Damage * 2;
                                else if (combatInventory.enemyAbil3Type == 4) combatInventory.solHealth -= combatInventory.enemyAbil3Damage * 2;
                                else if (combatInventory.enemyAbil4Type == 4) combatInventory.solHealth -= combatInventory.enemyAbil4Damage * 2;
                                attackBuffed = false;
                            }
                            else attackBuffed = true;
                            break;
                        default: //temporary-making sure no glitches or wasted enemy turns
                            combatInventory.solHealth -= combatInventory.enemyAbil1Damage;
                            break;
                    }
                }
                else if (charAttacked <= 30-(combatInventory.solHealth + combatInventory.astrumHealth) && charAttacked > 15-combatInventory.solHealth) //astrum attacked with first abil
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
                            combatInventory.astrumHealth -= combatInventory.enemyAbil1Damage;
                            combatInventory.astrumStunned = true;
                            break;
                        case 1:
                            combatInventory.enemyShield = true;
                            break;
                        case 2:
                            if (attackBuffed)
                            {
                                if (combatInventory.enemyAbil1Type == 4) combatInventory.astrumHealth -= combatInventory.enemyAbil1Damage * 2;
                                else if (combatInventory.enemyAbil2Type == 4) combatInventory.astrumHealth -= combatInventory.enemyAbil2Damage * 2;
                                else if (combatInventory.enemyAbil3Type == 4) combatInventory.astrumHealth -= combatInventory.enemyAbil3Damage * 2;
                                else if (combatInventory.enemyAbil4Type == 4) combatInventory.astrumHealth -= combatInventory.enemyAbil4Damage * 2;
                                attackBuffed = false;
                            }
                            else attackBuffed = true;
                            break;
                        default: //temporary
                            combatInventory.astrumHealth -= combatInventory.enemyAbil1Damage;
                            break;
                    }
                }
                else //ally attacked with first abil
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
                            combatInventory.allyHealth -= combatInventory.enemyAbil1Damage;
                            break;
                        case 1:
                            combatInventory.enemyShield = true;
                            break;
                        case 2:
                            if (attackBuffed)
                            {
                                if (combatInventory.enemyAbil1Type == 4) combatInventory.allyHealth -= combatInventory.enemyAbil1Damage * 2;
                                else if (combatInventory.enemyAbil2Type == 4) combatInventory.allyHealth -= combatInventory.enemyAbil2Damage * 2;
                                else if (combatInventory.enemyAbil3Type == 4) combatInventory.allyHealth -= combatInventory.enemyAbil3Damage * 2;
                                else if (combatInventory.enemyAbil4Type == 4) combatInventory.allyHealth -= combatInventory.enemyAbil4Damage * 2;
                                attackBuffed = false;
                            }
                            else attackBuffed = true;
                            break;
                        default: //temporary
                            combatInventory.allyHealth -= combatInventory.enemyAbil1Damage;
                            break;
                    }
                }
                Debug.Log("1st abil");
                combatInventory.prob1 = 1;
                combatInventory.prob2++;
                combatInventory.prob3++;
                combatInventory.prob4++;
            }
            else if(abilUsed<=(combatInventory.prob1+combatInventory.prob2)&&abilUsed>combatInventory.prob1) //2nd abil
            {
                if (charAttacked <= 15-combatInventory.solHealth) //sol attacked
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
                            combatInventory.solHealth -= combatInventory.enemyAbil2Damage;
                            break;
                        case 1:
                            combatInventory.enemyShield = true;
                            break;
                        case 2:
                            if (attackBuffed)
                            {
                                if (combatInventory.enemyAbil1Type == 4) combatInventory.solHealth -= combatInventory.enemyAbil1Damage * 2;
                                else if (combatInventory.enemyAbil2Type == 4) combatInventory.solHealth -= combatInventory.enemyAbil2Damage * 2;
                                else if (combatInventory.enemyAbil3Type == 4) combatInventory.solHealth -= combatInventory.enemyAbil3Damage * 2;
                                else if (combatInventory.enemyAbil4Type == 4) combatInventory.solHealth -= combatInventory.enemyAbil4Damage * 2;
                                attackBuffed = false;
                            }
                            else attackBuffed = true;
                            break;
                        default: //temporary
                            combatInventory.solHealth -= combatInventory.enemyAbil2Damage;
                            break;
                    }
                }
                else if (charAttacked <= 30-(combatInventory.solHealth + combatInventory.astrumHealth) && charAttacked > 15-combatInventory.solHealth) //astrum attacked
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
                            combatInventory.astrumHealth -= combatInventory.enemyAbil2Damage;
                            break;
                        case 1:
                            combatInventory.enemyShield = true;
                            break;
                        case 2:
                            if (attackBuffed)
                            {
                                if (combatInventory.enemyAbil1Type == 4) combatInventory.astrumHealth -= combatInventory.enemyAbil1Damage * 2;
                                else if (combatInventory.enemyAbil2Type == 4) combatInventory.astrumHealth -= combatInventory.enemyAbil2Damage * 2;
                                else if (combatInventory.enemyAbil3Type == 4) combatInventory.astrumHealth -= combatInventory.enemyAbil3Damage * 2;
                                else if (combatInventory.enemyAbil4Type == 4) combatInventory.astrumHealth -= combatInventory.enemyAbil4Damage * 2;
                                attackBuffed = false;
                            }
                            else attackBuffed = true;
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
                            combatInventory.allyHealth -= combatInventory.enemyAbil2Damage;
                            break;
                        case 1:
                            combatInventory.enemyShield = true;
                            break;
                        case 2:
                            if (attackBuffed)
                            {
                                if (combatInventory.enemyAbil1Type == 4) combatInventory.allyHealth -= combatInventory.enemyAbil1Damage * 2;
                                else if (combatInventory.enemyAbil2Type == 4) combatInventory.allyHealth -= combatInventory.enemyAbil2Damage * 2;
                                else if (combatInventory.enemyAbil3Type == 4) combatInventory.allyHealth -= combatInventory.enemyAbil3Damage * 2;
                                else if (combatInventory.enemyAbil4Type == 4) combatInventory.allyHealth -= combatInventory.enemyAbil4Damage * 2;
                                attackBuffed = false;
                            }
                            else attackBuffed = true;
                            break;
                        default: //temporary
                            combatInventory.allyHealth -= combatInventory.enemyAbil2Damage;
                            break;
                    }
                }
                Debug.Log("2nd abil");
                combatInventory.prob1++;
                combatInventory.prob2=1;
                combatInventory.prob3++;
                combatInventory.prob4++;
            }
            else if (abilUsed <= (combatInventory.prob1 + combatInventory.prob2+combatInventory.prob3) && abilUsed > combatInventory.prob2)
            {
                if (charAttacked <= 15-combatInventory.solHealth)
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
                            combatInventory.solHealth -= combatInventory.enemyAbil3Damage;
                            break;
                        case 1:
                            combatInventory.enemyShield = true;
                            break;
                        case 2:
                            if (attackBuffed)
                            {
                                if (combatInventory.enemyAbil1Type == 4) combatInventory.solHealth -= combatInventory.enemyAbil1Damage * 2;
                                else if (combatInventory.enemyAbil2Type == 4) combatInventory.solHealth -= combatInventory.enemyAbil2Damage * 2;
                                else if (combatInventory.enemyAbil3Type == 4) combatInventory.solHealth -= combatInventory.enemyAbil3Damage * 2;
                                else if (combatInventory.enemyAbil4Type == 4) combatInventory.solHealth -= combatInventory.enemyAbil4Damage * 2;
                                attackBuffed = false;
                            }
                            else attackBuffed = true;
                            break;
                        default: //temporary
                            combatInventory.solHealth -= combatInventory.enemyAbil3Damage;
                            break;
                    }
                }
                else if (charAttacked <= 30-(combatInventory.solHealth + combatInventory.astrumHealth) && charAttacked > 15-combatInventory.solHealth)
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
                            combatInventory.astrumHealth -= combatInventory.enemyAbil3Damage;
                            break;
                        case 1:
                            combatInventory.enemyShield = true;
                            break;
                        case 2:
                            if (attackBuffed)
                            {
                                if (combatInventory.enemyAbil1Type == 4) combatInventory.astrumHealth -= combatInventory.enemyAbil1Damage * 2;
                                else if (combatInventory.enemyAbil2Type == 4) combatInventory.astrumHealth -= combatInventory.enemyAbil2Damage * 2;
                                else if (combatInventory.enemyAbil3Type == 4) combatInventory.astrumHealth -= combatInventory.enemyAbil3Damage * 2;
                                else if (combatInventory.enemyAbil4Type == 4) combatInventory.astrumHealth -= combatInventory.enemyAbil4Damage * 2;
                                attackBuffed = false;
                            }
                            else attackBuffed = true;
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
                            if (attackBuffed)
                            {
                                if (combatInventory.enemyAbil1Type == 4) combatInventory.allyHealth -= combatInventory.enemyAbil1Damage * 2;
                                else if (combatInventory.enemyAbil2Type == 4) combatInventory.allyHealth -= combatInventory.enemyAbil2Damage * 2;
                                else if (combatInventory.enemyAbil3Type == 4) combatInventory.allyHealth -= combatInventory.enemyAbil3Damage * 2;
                                else if (combatInventory.enemyAbil4Type == 4) combatInventory.allyHealth -= combatInventory.enemyAbil4Damage * 2;
                                attackBuffed = false;
                            }
                            else attackBuffed = true;
                            break;
                        default: //temporary
                            combatInventory.allyHealth -= combatInventory.enemyAbil3Damage;
                            break;
                    }
                }
                Debug.Log("3rd abil");
                combatInventory.prob1++; 
                combatInventory.prob2++;
                combatInventory.prob3=1;
                combatInventory.prob4++;
            }
            else 
            {
                if (charAttacked <= 15-combatInventory.solHealth)
                {
                    switch (combatInventory.enemyAbil4Type)
                    {
                        case 4:
                            if (attackBuffed)
                            {
                                combatInventory.solHealth -= combatInventory.enemyAbil4Damage * 2;
                                attackBuffed = false;
                            }
                            else combatInventory.solHealth -= combatInventory.enemyAbil4Damage;
                            break;
                        case 0:
                            combatInventory.enemyHealth += combatInventory.enemyAbil4Damage;
                            break;
                        case 3:
                            combatInventory.solStunned = true;
                            combatInventory.solHealth -= combatInventory.enemyAbil4Damage;
                            break;
                        case 1:
                            combatInventory.enemyShield = true;
                            break;
                        case 2:
                            if (attackBuffed)
                            {
                                if (combatInventory.enemyAbil1Type == 4) combatInventory.solHealth -= combatInventory.enemyAbil1Damage * 2;
                                else if (combatInventory.enemyAbil2Type == 4) combatInventory.solHealth -= combatInventory.enemyAbil2Damage * 2;
                                else if (combatInventory.enemyAbil3Type == 4) combatInventory.solHealth -= combatInventory.enemyAbil3Damage * 2;
                                else if (combatInventory.enemyAbil4Type == 4) combatInventory.solHealth -= combatInventory.enemyAbil4Damage * 2;
                                attackBuffed = false;
                            }
                            else attackBuffed = true;
                            break;
                        default: //temporary
                            combatInventory.solHealth -= combatInventory.enemyAbil4Damage;
                            break;
                    }
                }
                else if (charAttacked <= 30-(combatInventory.solHealth + combatInventory.astrumHealth) && charAttacked > 15-combatInventory.solHealth)
                {
                    switch (combatInventory.enemyAbil4Type)
                    {
                        case 4:
                            if (attackBuffed)
                            {
                                combatInventory.astrumHealth -= combatInventory.enemyAbil4Damage * 2;
                                attackBuffed = false;
                            }
                            else combatInventory.astrumHealth -= combatInventory.enemyAbil4Damage;
                            break;
                        case 0:
                            combatInventory.enemyHealth += combatInventory.enemyAbil4Damage;
                            break;
                        case 3:
                            combatInventory.astrumStunned = true;
                            combatInventory.astrumHealth -= combatInventory.enemyAbil4Damage;
                            break;
                        case 1:
                            combatInventory.enemyShield = true;
                            break;
                        case 2:
                            if (attackBuffed)
                            {
                                if (combatInventory.enemyAbil1Type == 4) combatInventory.astrumHealth -= combatInventory.enemyAbil1Damage * 2;
                                else if (combatInventory.enemyAbil2Type == 4) combatInventory.astrumHealth -= combatInventory.enemyAbil2Damage * 2;
                                else if (combatInventory.enemyAbil3Type == 4) combatInventory.astrumHealth -= combatInventory.enemyAbil3Damage * 2;
                                else if (combatInventory.enemyAbil4Type == 4) combatInventory.astrumHealth -= combatInventory.enemyAbil4Damage * 2;
                                attackBuffed = false;
                            }
                            else attackBuffed = true;
                            break;
                        default: //temporary
                            combatInventory.astrumHealth -= combatInventory.enemyAbil4Damage;
                            break;
                    }
                }
                else
                {
                    switch (combatInventory.enemyAbil4Type)
                    {
                        case 4:
                            if (attackBuffed)
                            {
                                combatInventory.allyHealth -= combatInventory.enemyAbil4Damage * 2;
                                attackBuffed = false;
                            }
                            else combatInventory.allyHealth -= combatInventory.enemyAbil4Damage;
                            break;
                        case 0:
                            combatInventory.enemyHealth += combatInventory.enemyAbil4Damage;
                            break;
                        case 3:
                            combatInventory.allyStunned = true;
                            combatInventory.allyHealth -= combatInventory.enemyAbil4Damage;
                            break;
                        case 1:
                            combatInventory.enemyShield = true;
                            break;
                        case 2:
                            if (attackBuffed)
                            {
                                if (combatInventory.enemyAbil1Type == 4) combatInventory.allyHealth -= combatInventory.enemyAbil1Damage * 2;
                                else if (combatInventory.enemyAbil2Type == 4) combatInventory.allyHealth -= combatInventory.enemyAbil2Damage * 2;
                                else if (combatInventory.enemyAbil3Type == 4) combatInventory.allyHealth -= combatInventory.enemyAbil3Damage * 2;
                                else if (combatInventory.enemyAbil4Type == 4) combatInventory.allyHealth -= combatInventory.enemyAbil4Damage * 2;
                                attackBuffed = false;
                            }
                            else attackBuffed = true;
                            break;
                        default: //temporary
                            combatInventory.allyHealth -= combatInventory.enemyAbil4Damage;
                            break;
                    }
                }
                Debug.Log("4th abil");
                combatInventory.prob1++;
                combatInventory.prob2++;
                combatInventory.prob3++;
                combatInventory.prob4 = 1;
            }
            if (combatInventory.enemyAbil1Type == 4) combatInventory.enemyAbil1Type++; //gives attack more probability to come up relative to other abilities
            if (combatInventory.enemyAbil2Type == 4) combatInventory.enemyAbil2Type++;
            if (combatInventory.enemyAbil3Type == 4) combatInventory.enemyAbil3Type++;
            if (combatInventory.enemyAbil4Type == 4) combatInventory.enemyAbil4Type++;
            if(combatInventory.solHealth<0) combatInventory.solHealth = 0; //putting this here to save space in update function
            if (combatInventory.astrumHealth < 0) combatInventory.astrumHealth = 0;
            if (combatInventory.allyHealth < 0) combatInventory.allyHealth = 0;
            combatInventory.playerTurn = true;
            combatInventory.rounds++;
        }//end enemy turn

    }

}
