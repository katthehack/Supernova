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
            int abilUsed = rnd.Next(0,combatInventory.prob1+ combatInventory.prob2+ combatInventory.prob3 + combatInventory.prob4+1); //+1 to include upper bound
            int charAttacked = rnd.Next(0, 2); //0 for sol, 1 for astrum, 2 for ally
            //add probabiltiy to which ally has higher/lower health same way as enemy probability
            Debug.Log("abil used-" + abilUsed + " charAttacked-"+charAttacked);

            if (abilUsed<=combatInventory.prob1)
            {
                if (charAttacked == 0) combatInventory.solHealth-=combatInventory.enemyAbil1Damage; //rn all abilities damage-add checks for abiltype later
                if (charAttacked == 1) combatInventory.astrumHealth -= combatInventory.enemyAbil1Damage; 
                if (charAttacked == 2) combatInventory.allyHealth -= combatInventory.enemyAbil1Damage;
                Debug.Log("1st abil");
            }
            else if(abilUsed<=(combatInventory.prob1+combatInventory.prob2)&&abilUsed>combatInventory.prob1)
            {
                if (charAttacked == 0) combatInventory.solHealth -= combatInventory.enemyAbil2Damage; 
                if (charAttacked == 1) combatInventory.astrumHealth -= combatInventory.enemyAbil2Damage;
                if (charAttacked == 2) combatInventory.allyHealth -= combatInventory.enemyAbil2Damage;
                Debug.Log("2nd abil");
            }
            else if (abilUsed <= (combatInventory.prob1 + combatInventory.prob2+combatInventory.prob3) && abilUsed > combatInventory.prob2)
            {
                if (charAttacked == 0) combatInventory.solHealth -= combatInventory.enemyAbil3Damage;
                if (charAttacked == 1) combatInventory.astrumHealth -= combatInventory.enemyAbil3Damage;
                if (charAttacked == 2) combatInventory.allyHealth -= combatInventory.enemyAbil3Damage;
                Debug.Log("3rd abil");
            }
            else
            {
                Debug.Log("4th abil");
            }
            
            combatInventory.playerTurn = true;
            combatInventory.rounds++;
        }

    }

}
