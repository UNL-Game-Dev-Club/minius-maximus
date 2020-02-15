using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int maxHealth;
    public int strength;
    public int defense;
    public int currentHealth;

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
