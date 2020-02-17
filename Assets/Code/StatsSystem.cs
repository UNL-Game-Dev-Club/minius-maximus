using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatsSystem : MonoBehaviour
{
    //Text numbers for each player stat
    public Text healthStatsText;
    public Text strengthStatsText;
    public Text defenseStatsText;
    public Text speedStatsText;
    public Text statPointsText;
    
    //Set stats variablies
    public int statPoints = 0;
    public int healthStat;
    public int strengthStat;
    public int defenseStat;
    public int speedStat;

    public GameObject playerPrefab;



    // Start is called before the first frame update
    void Start()
    {
        SetStats();
    }

    //Sets the non-static stat variables to the players stats and updates the text
    public void SetStats()
    {
        healthStat = PlayerUnit.currentHealth;
        strengthStat = PlayerUnit.strength;
        defenseStat = PlayerUnit.defense;
        speedStat = PlayerUnit.speed;

        healthStatsText.text = healthStat.ToString();
        strengthStatsText.text = strengthStat.ToString();
        defenseStatsText.text = defenseStat.ToString();
        speedStatsText.text = speedStat.ToString();
        statPointsText.text = statPoints.ToString();
    }

   
    public void OnBackButton()
    {
        SceneManager.LoadScene("Combat");
    }

    //Sets the changes made to the non-static variables to the player's stats and loads combat scene back up
    public void OnApplyButton()
    {
        if (statPoints == 0)
        {
            PlayerUnit.currentHealth = healthStat;
            PlayerUnit.strength = strengthStat;
            PlayerUnit.defense = defenseStat;
            PlayerUnit.speed = speedStat;

            if (PlayerUnit.currentHealth > PlayerUnit.maxHealth)
            {
                PlayerUnit.maxHealth = PlayerUnit.currentHealth;
            }

            SceneManager.LoadScene("Combat");
        }
    }

    //Methods for the + and - buttons for each stat
    //+ Adds the stat and minus the stat points var and updates the texts to display the number
    //- Subtracts the stat and adds one to stat points var and updates the texts involved. 
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

    public void AddSpeed()
    {
        if (statPoints > 0)
        {
            statPoints--;
            speedStat++;

            speedStatsText.text = speedStat.ToString();
            statPointsText.text = statPoints.ToString();
        }
    }

    public void SubtractSpeed()
    {
        if(speedStat - 1 > -1)
        {
            speedStat--;
            statPoints++;

            speedStatsText.text = speedStat.ToString();
            statPointsText.text = statPoints.ToString();
        }
    }
 
}
