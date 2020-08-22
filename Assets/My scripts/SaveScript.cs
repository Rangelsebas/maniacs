using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
    public static int PlayerHealth = 85;

    public static bool healtChange = false;

    public static float batteryPower = 1.0f;
    public static bool batteryRefill = false;

    public static bool flashLightOn = false;
    public static bool nvLightOn = false;

    //apples
    public static int apples = 0;

    //baterries
    public static int batteries = 0;

    //weapons
    public static bool knife = false; 
    public static bool bat = false;
    public static bool axe = false;
    public static bool gun = false;
    public static bool crossbow = false;

    //keys
    public static bool cabinKey = false;
    public static bool houseKey = false;
    public static bool roomKey = false;

    //ammo
    public static bool arrowAmmo = false;
    public static int gunAmmo = 0;
    
}
