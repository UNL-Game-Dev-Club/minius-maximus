using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RewardStatPoints : MonoBehaviour
{
    public GameObject statsSystem;
    StatsSystem stats;

    private void Start()
    {
        stats = statsSystem.GetComponent<StatsSystem>();
        stats.statPoints++;
        stats.statPointsText.text = stats.statPoints.ToString();
        PlayerUnit.currentHealth = PlayerUnit.maxHealth;
        stats.healthStatsText.text = PlayerUnit.currentHealth.ToString();
        stats.healthStat = PlayerUnit.currentHealth;
    }

    public void OnContinueButton()
    {
        if (stats.statPoints == 0)
        {
            PlayerUnit.maxHealth = stats.healthStat;
            PlayerUnit.strength = stats.strengthStat;
            PlayerUnit.defense = stats.defenseStat;

            SceneManager.LoadScene("Overworld");
        }
    }
}
