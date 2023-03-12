using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCombat : MonoBehaviour
{
    public CombatInventory combatInventory;
    public EnemyCombat enemyCombat;
    public PlayerCombat playerCombat;
    KeyCode input = KeyCode.E;

    private void Start()
    {
        combatInventory = gameObject.GetComponent<CombatInventory>();
        enemyCombat = gameObject.GetComponent<EnemyCombat>();
        playerCombat = gameObject.GetComponent<PlayerCombat>();
    }
    // Update is called once per frame
    void Update()
    {

        if (combatInventory.playerTurn && Input.GetKeyDown(input))
        {
            combatInventory.enemyHealth--;
            combatInventory.playerTurn = false;
        }
        if (combatInventory.playerHealth == 0)
        {
            SceneManager.LoadScene("");
        }
        else if (combatInventory.enemyHealth == 0)
        {

        }
    }
}
