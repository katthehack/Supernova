using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public CombatInventory combatInventory;
    public EnemyCombat enemyCombat;
    public PlayerCombat playerCombat;
    KeyCode input = KeyCode.E;

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
            combatInventory.playerHealth--;
            combatInventory.playerTurn = true;
            combatInventory.rounds++;
        }
    }
}
