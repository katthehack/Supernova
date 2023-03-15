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
    public String solAbil2 = "Not Availible";
    public String solAbil3 = "Not Available";
    public String solAbil4 = "Not Available";

    public String astrumAbil1 = "Radiation";
    public String astrumAbil2 = "Heaven's Blessing";
    public String astrumAbil3 = "Glory";
    public String astrumAbil4 = "Celestial Cartography";

    public String allyAbil1 = "Not Availible";
    public String allyAbil2 = "Not Availible";
    public String allyAbil3 = "Not Availible";
    public String allyAbil4 = "Not Availible";

}
