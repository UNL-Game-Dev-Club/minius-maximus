using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RewardStatPoints : MonoBehaviour
{
    /*Used in victory scene where the player puts in their new stats.
     It's more of a manager since we're still using the StatsSystem.cs script
     to edit the stats in this scene.*/
    
    //References the stats HUD in this scene
    public GameObject statsSystem;

    //Reference to the combat stats system
    StatsSystem stats;

    //Sets the stats in this scene to the players and updates the text UI
    private void Start()
    {
        stats = statsSystem.GetComponent<StatsSystem>();
        stats.statPoints = PlayerUnit.totalDamage + 2;
        stats.statPointsText.text = stats.statPoints.ToString();
        stats.healthStatsText.text = PlayerUnit.currentHealth.ToString();
        stats.healthStat = PlayerUnit.currentHealth;
    }

    //Changes the players stats to adjustments made in this scene when Continue is pressed
    public void OnContinueButton()
    {
        if (stats.statPoints == 0)
        {
            PlayerUnit.maxHealth = stats.healthStat;
            PlayerUnit.currentHealth = stats.healthStat;
            PlayerUnit.strength = stats.strengthStat;
            PlayerUnit.defense = stats.defenseStat;
            PlayerUnit.speed = stats.speedStat;
            PlayerUnit.totalDamage = 0;

            SceneManager.LoadScene("Overworld");
        }
    }
}
