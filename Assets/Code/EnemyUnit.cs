using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : MonoBehaviour
{
    //Stores all of our enemy sprites to the enemy unit prefab
    public List<Sprite> sprites;

    //Stat variables
    public static int maxHealth = 6;
    public static int strength = 3;
    public static int defense = 3;
    public static int currentHealth = 6;
    public static int speed;

    //Used in SetSprite() to refernce the correct sprite in the sprites list
    //You set enemyNumber in DialogueTrig
    public static int enemyNumber;

    private SpriteRenderer spriteRenderer;

    //Sets the spriteRenderer to the sprite of the enemy and changes it
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetSprite();
    }

    //Sets the sprite of the enemy from the sprites list
    private void SetSprite()
    {
        spriteRenderer.sprite = sprites[enemyNumber];
    }

    //Used to deal damage to an object based off the attackers strength and the targets defense
    public bool TakeDamage(int strength, int defense)
    {
        //Prevents Damage Going Negative
        if (defense / 2 >= strength)
        {
            currentHealth -= 1;
        }
        //Stores the damage taken and subtracts from current health
        else
        {
            currentHealth -= strength - defense / 2;
        }

        //Checks if the thing taking damage is still alive
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
