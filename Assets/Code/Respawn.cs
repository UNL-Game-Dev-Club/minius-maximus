using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{ 
    //Sets player's stats back to before they collided with the enemy
    //Total damage is set to 0 so those stat points don't carry over
    public void ResetStats()
    {
        PlayerUnit.maxHealth = PlayerUnit.healthBefore;
        PlayerUnit.currentHealth = PlayerUnit.healthBefore;
        PlayerUnit.strength = PlayerUnit.strengthBefore;
        PlayerUnit.defense = PlayerUnit.defenseBefore;
        PlayerUnit.speed = PlayerUnit.speedBefore;
        PlayerUnit.totalDamage = 0;
        SceneManager.LoadScene("Overworld");
    }
}
