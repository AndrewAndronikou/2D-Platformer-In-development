using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Health;
    public int startHealth = 3;

    public static bool hasDied;

    public static int Score;
    public int startScore = 0;

    public static int Apple;
    public int startApple = 0;

    public static int Kiwi;
    public int startKiwi = 0;

    public static int Bananas;
    public int startBananas = 0;

    public static int Cherries;
    public int startCherries = 0;

    public static int Melon;
    public int startMelon = 0;

    public static int Orange;
    public int startOrange = 0;

    public static int Pineapple;
    public int startPineapple = 0;

    public static int Strawberry;
    public int startStrawberry = 0;

    private void Awake()
    {
        Health = startHealth;
        Score = startScore;

        //Collectables
        Apple = startApple;
        Kiwi = startKiwi;
        Bananas = startBananas;
        Cherries = startCherries;
        Melon = startMelon;
        Orange = startOrange;
        Pineapple = startPineapple;
        Strawberry = startStrawberry;
    }
}
