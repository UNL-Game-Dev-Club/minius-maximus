using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatsSystem : MonoBehaviour
{
    public Text healthStatsText;
    public Text strengthStatsText;
    public Text defenseStatsText;
    public Text statPointsText;

    public int statPoints = 0;
    public int healthStat;
    public int strengthStat;
    public int defenseStat;

    public GameObject playerPrefab;

    BattleSystem battleSystem;



    // Start is called before the first frame update
    void Start()
    {
        SetStats();
    }

    public void SetStats()
    {
        healthStat = PlayerUnit.currentHealth;
        strengthStat = PlayerUnit.strength;
        defenseStat = PlayerUnit.defense;

        healthStatsText.text = healthStat.ToString();
        strengthStatsText.text = strengthStat.ToString();
        defenseStatsText.text = defenseStat.ToString();
        statPointsText.text = statPoints.ToString();
    }

    public void OnBackButton()
    {
        SceneManager.LoadScene("Combat");
    }

    public void OnApplyButton()
    {
        if (statPoints == 0)
        {
            PlayerUnit.currentHealth = healthStat;
            PlayerUnit.strength = strengthStat;
            PlayerUnit.defense = defenseStat;

            SceneManager.LoadScene("Combat");
        }
    }


    public void AddHealth()
    {
        if(statPoints > 0)
        {
            statPoints--;
            healthStat++;

            healthStatsText.text = healthStat.ToString();
            statPointsText.text = statPoints.ToString();
        }

    }

    public void SubtractHealth()
    {
        if (healthStat - 1 > 0)
        {
            healthStat--;
            statPoints++;

            healthStatsText.text = healthStat.ToString();
            statPointsText.text = statPoints.ToString();
        }
    }

    public void AddStrength()
    {
        if (statPoints > 0)
        {
            statPoints--;
            strengthStat++;

            strengthStatsText.text = strengthStat.ToString();
            statPointsText.text = statPoints.ToString();
        }
    }

    public void SubtractStrength()
    {
        if (strengthStat - 1 > -1)
        {
            strengthStat--;
            statPoints++;

            strengthStatsText.text = strengthStat.ToString();
            statPointsText.text = statPoints.ToString();
        }
    }

    public void AddDefense()
    {
        if (statPoints > 0)
        {
            statPoints--;
            defenseStat++;

            defenseStatsText.text = defenseStat.ToString();
            statPointsText.text = statPoints.ToString();
        }
    }

    public void SubtractDefense()
    {
        if (defenseStat - 1 > -1)
        {
            defenseStat--;
            statPoints++;

            defenseStatsText.text = defenseStat.ToString();
            statPointsText.text = statPoints.ToString();
        }
    }
 
}
