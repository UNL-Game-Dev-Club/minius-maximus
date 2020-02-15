using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : MonoBehaviour
{
    public static int maxHealth;
    public static int strength = 3;
    public static int defense = 3;
    public static int currentHealth = 20;

    private void Awake()
    {
        maxHealth = 20;
    }

    public bool TakeDamage(int strength, int defense)
    {
        currentHealth -= strength - defense / 2;

        if (currentHealth <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
