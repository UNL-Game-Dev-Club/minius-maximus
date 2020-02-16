using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    public static int maxHealth = 4;
    public static int strength = 3;
    public static int defense = 3;
    public static int currentHealth = 4;
    public static int speed = 3;

    public static int totalDamage = 0;


    public bool TakeDamage(int strength, int defense)
    {
        //Prevents Damage Going Negative
        if (defense >= strength)
        {
            currentHealth -= 1;
            totalDamage += 1;
        }
        else
        {
            int damage = strength - defense;
            currentHealth -= damage;
            totalDamage += damage;
        }


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
