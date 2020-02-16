using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public void ResetStats()
    {
        PlayerUnit.totalDamage = 0;
        PlayerUnit.currentHealth = PlayerUnit.maxHealth;
        SceneManager.LoadScene("Overworld");
    }
}
