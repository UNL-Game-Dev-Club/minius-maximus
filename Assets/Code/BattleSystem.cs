using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    BattleState state;
    //Config variables
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject attackButton;
    public GameObject statsButton;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    public UnitHUD playerHUD;
    public UnitHUD enemyHUD;

    public Text displayText;

    public GameObject playerStats;
    public GameObject enemyStats;

    //Instance of Player and Enemy
    PlayerUnit playerUnit;
    PlayerUnit enemyUnit;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        //Calls the SetUpBattle function
        StartCoroutine(SetUpBattle());
    }

    IEnumerator SetUpBattle()
    {
        //Spawns player prefab and assigns its stats to the playerUnit var
        GameObject playerGo = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGo.GetComponent<PlayerUnit>();
        //Spawns enemy prefab and assigns its stats to the enemyUnit var
        GameObject enemyGo = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGo.GetComponent<PlayerUnit>();
        //Assigns the health bar to each units health stat
        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(0.1f);
        //Switchs the turns to playerturn
        state = BattleState.PLAYERTURN;
        PlayerTurn();
        
    }
    //Allows the player to use buttons
    private void PlayerTurn()
    {
        attackButton.SetActive(true);
        statsButton.SetActive(true);
    }

    //function that runs on attack button press
    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
        StartCoroutine(PlayerAttack());
    }

    public void OnStatsButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
        SceneManager.LoadScene("CombatStatsEditor");
    }

 
    IEnumerator PlayerAttack()
    {
        //Turns buttons off so player cannot attack twice
        DisableButton();
        //Calls the Take Damage function in the Unit.cs script and assings it to bool isDead to check if enemy dies
        bool isDead = enemyUnit.TakeDamage(PlayerUnit.strength, PlayerUnit.defense);

        enemyHUD.SetHp(PlayerUnit.currentHealth);

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        bool isDead = playerUnit.TakeDamage(PlayerUnit.strength, PlayerUnit.defense);

        playerHUD.SetHp(PlayerUnit.currentHealth);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    private void EndBattle()
    {
        if (state == BattleState.WON)
        {
            displayText.text = "You Win!";
        }
        else if (state == BattleState.LOST)
        {
            displayText.text = "Pathetic. Try again.";
        }
    }

    public void DisableButton()
    {
        attackButton.SetActive(false);
        statsButton.SetActive(false);
    }
}
