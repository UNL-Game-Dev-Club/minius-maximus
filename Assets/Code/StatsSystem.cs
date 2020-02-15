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

    public GameObject playerPrefab;

    PlayerUnit player;


    // Start is called before the first frame update
    void Start()
    {
        player = playerPrefab.GetComponent<PlayerUnit>();
        SetStats();
    }

    public void SetStats()
    {
        int healthStat = PlayerUnit.currentHealth;
        int strengthStat = PlayerUnit.strength;
        int defenseStat = PlayerUnit.defense;

        healthStatsText.text = healthStat.ToString();
        strengthStatsText.text = strengthStat.ToString();
        defenseStatsText.text = defenseStat.ToString();
    }

    public void OnBackButton()
    {
        SceneManager.LoadScene("Combat");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
