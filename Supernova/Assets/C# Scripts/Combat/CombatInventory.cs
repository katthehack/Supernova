using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class CombatInventory : MonoBehaviour
{
    public int solHealth;
    public int astrumHealth;
    public int allyHealth;
    public int enemyHealth;
    public Boolean playerTurn = true;
    public int rounds;

    public String solAbil1 = "Slingshot";
    public int solAbil11dmg = 2;
    public String solAbil2 = "Not Available";
    public int solAbil12dmg = 2;
    public String solAbil3 = "Not Available";
    public int solAbil13dmg = 2;
    public String solAbil4 = "Not Available";
    public int solAbil41dmg = 2;

    public String astrumAbil1 = "Radiation"; //buffs attack by 2
    public int astrumAbil1dmg = 2;
    public String astrumAbil2 = "Heaven's Blessing"; //heals a selected character by 2
    public int astrumAbil2dmg = 2;
    public String astrumAbil3 = "Glory"; //increases effect of items by 3
    public int astrumAbil3dmg = 3;
    public String astrumAbil4 = "Celestial Cartography"; //increased damage against selected target by 3
    public int astrumAbil4dmg = 3;

    public String allyAbil1 = "Not Available";
    public String allyAbil2 = "Not Avaiaible";
    public String allyAbil3 = "Not Available";
    public String allyAbil4 = "Not Available";

    public String item1 = "Not Available";
    public String item2 = "Not Available";
    public String item3 = "Not Available";
    public String item4 = "Not Available";

    public String enemyAbil1 = "Venom";
    public int enemyAbil1Type = 4; //0-heal, 1-shield, 2-attack buff, 3-stun, 4-attack
    public int enemyAbil1Damage = 2;
    public String enemyAbil2 = "Paralyze";
    public int enemyAbil12ype = 3; //higher the # higher the probability, numbers change after start
    public int enemyAbil2Damage = 1;
    public String enemyAbil3 = "Bravery";
    public int enemyAbil3Type = 2;
    public int enemyAbil3Damage = 3;
    public String enemyAbil4 = "Exoskeleton";
    public int enemyAbil4Type = 1;
    public float enemyAbil4Damage = 0.5f;

    public int prob1 = 4;
    public int prob2 = 3;
    public int prob3 = 2;
    public int prob4 = 1;
}
