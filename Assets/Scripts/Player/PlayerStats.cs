﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Health;
    public int startHealth = 3;

    public static bool hasDied;

    public static int Score;
    public int startScore = 0;

    private void Awake()
    {
        Health = startHealth;
        Score = startScore;
    }
}
