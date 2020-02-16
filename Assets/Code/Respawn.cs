using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
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
