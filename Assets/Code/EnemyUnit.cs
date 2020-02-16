using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : MonoBehaviour
{
    DialogueTrig fight;
    public List<Sprite> sprites;

    public static int maxHealth = 6;
    public static int strength = 3;
    public static int defense = 3;
    public static int currentHealth = 6;
    public static int enemyNumber;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        fight = GetComponent<DialogueTrig>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetSprite();
    }

    private void SetSprite()
    {
        spriteRenderer.sprite = sprites[enemyNumber];
    }

    public bool TakeDamage(int strength, int defense)
    {
        if (defense / 2 >= strength)
        {
            currentHealth -= 1;
        }
        else
        {
            currentHealth -= strength - defense/ 2;
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
