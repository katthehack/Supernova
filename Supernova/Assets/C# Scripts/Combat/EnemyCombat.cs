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

    private void Start()
    {
        combatInventory=gameObject.GetComponent<CombatInventory>();
        enemyCombat=gameObject.GetComponent<EnemyCombat>();
        playerCombat=gameObject.GetComponent<PlayerCombat>();
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
                if (charAttacked <= combatInventory.solHealth) combatInventory.solHealth-=combatInventory.enemyAbil1Damage; //rn all abilities damage-add checks for abiltype later
                else if (charAttacked <= combatInventory.solHealth+ combatInventory.astrumHealth&&charAttacked> combatInventory.solHealth) combatInventory.astrumHealth -= combatInventory.enemyAbil1Damage; 
                else combatInventory.allyHealth -= combatInventory.enemyAbil1Damage;
                Debug.Log("1st abil-charAttacked = "+charAttacked);
                combatInventory.prob1 = 1;
                combatInventory.prob2++;
                combatInventory.prob3++;
                combatInventory.prob4++;
            }
            else if(abilUsed<=(combatInventory.prob1+combatInventory.prob2)&&abilUsed>combatInventory.prob1)
            {
                if (charAttacked <= combatInventory.solHealth) combatInventory.solHealth -= combatInventory.enemyAbil2Damage; //rn all abilities damage-add checks for abiltype later
                else if (charAttacked <= combatInventory.solHealth + combatInventory.astrumHealth && charAttacked > combatInventory.solHealth) combatInventory.astrumHealth -= combatInventory.enemyAbil2Damage;
                else combatInventory.allyHealth -= combatInventory.enemyAbil2Damage;
                Debug.Log("2nd abil-charAttacked = "+charAttacked);
                combatInventory.prob1++;
                combatInventory.prob2=1;
                combatInventory.prob3++;
                combatInventory.prob4++;
            }
            else if (abilUsed <= (combatInventory.prob1 + combatInventory.prob2+combatInventory.prob3) && abilUsed > combatInventory.prob2)
            {
                if (charAttacked <= combatInventory.solHealth) combatInventory.solHealth -= combatInventory.enemyAbil3Damage; //rn all abilities damage-add checks for abiltype later
                else if (charAttacked <= combatInventory.solHealth + combatInventory.astrumHealth && charAttacked > combatInventory.solHealth) combatInventory.astrumHealth -= combatInventory.enemyAbil3Damage;
                else combatInventory.allyHealth -= combatInventory.enemyAbil3Damage;
                Debug.Log("3rd abil-charAttacked = " + charAttacked);
                combatInventory.prob1++; ;
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
