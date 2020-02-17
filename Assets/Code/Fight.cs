using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fight : MonoBehaviour
{
    //Not used anymore should probably delete
    public int health;
    public int strength;
    public int defense;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyUnit.currentHealth = health;
        EnemyUnit.maxHealth = health;
        EnemyUnit.strength = strength;
        EnemyUnit.defense = defense;

        PlayerUnit.currentHealth = PlayerUnit.maxHealth;

        SceneManager.LoadScene("Combat");
    }
}
