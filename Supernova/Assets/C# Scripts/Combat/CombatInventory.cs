using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class CombatInventory : MonoBehaviour
{
    public int playerHealth;
    public int enemyHealth;
    public Boolean playerTurn = true;
    public int rounds;

    public String solAbil1 = "Slingshot";
    public int solAbil11dmg = 2;
    public String solAbil2 = "Not Availible";
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

    public String allyAbil1 = "Not Availible";
    public String allyAbil2 = "Not Availible";
    public String allyAbil3 = "Not Availible";
    public String allyAbil4 = "Not Availible";

    public String item1 = "Not Available";
    public String item2 = "Not Available";
    public String item3 = "Not Available";
    public String item4 = "Not Available";


}
