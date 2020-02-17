using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Different states the in combat
public enum BattleState { START, FIGHT, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    //Reference of enum
    BattleState state;

    //Config variables
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject attackButton;
    public GameObject statsButton;
    public GameObject battleHUD;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    public UnitHUD playerHUD;
    public UnitHUD enemyHUD;

    public Text displayText;

    //Instance of Player and Enemy
    PlayerUnit playerUnit;
    EnemyUnit enemyUnit;

    public static AudioSource fightMusic;
    public static AudioSource bossMusic;
    public AudioSource hitSound;
    public static bool playingMusic = false;


    // Sets state to start, plays fighting music, and calls SetUpBattle()
    void Start()
    {
        state = BattleState.START;

        if (!playingMusic)
        {
            fightMusic = GameObject.Find("Fight").GetComponent<AudioSource>();
            bossMusic = GameObject.Find("Boss").GetComponent<AudioSource>();
            DontDestroyOnLoad(fightMusic);
            DontDestroyOnLoad(bossMusic);
            if (EnemyUnit.enemyNumber == 7)
            {
                bossMusic.Play();
            }
            else
            {
                fightMusic.Play();
            }
            playingMusic = true;
        }

        StartCoroutine(SetUpBattle());
    }

  
    //Coroutine used to setup the combat scene
    IEnumerator SetUpBattle()
    {

        //Spawns player prefab and assigns its stats to the playerUnit var
        GameObject playerGo = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGo.GetComponent<PlayerUnit>();
        playerGo.transform.SetPositionAndRotation(new Vector3(playerBattleStation.transform.position.x, playerBattleStation.transform.position.y, -1), Quaternion.identity);

        //Spawns enemy prefab and assigns its stats to the enemyUnit var
        GameObject enemyGo = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGo.GetComponent<EnemyUnit>();
        enemyGo.transform.SetPositionAndRotation(new Vector3(enemyBattleStation.transform.position.x, enemyBattleStation.transform.position.y, -1), Quaternion.identity);
        //Assigns the health bar to each units health stat
        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(0.1f);
        //Switchs the turns to playerturn
       
        state = BattleState.FIGHT;
        PlayerTurn();
 
    }
    //Allows the player to use buttons
    private void PlayerTurn()
    {
        battleHUD.SetActive(true);
        attackButton.SetActive(true);
        statsButton.SetActive(true);
    }

    //function that runs on attack button press
    public void OnAttackButton()
    {
        if (state == BattleState.FIGHT)
        {
            StartCoroutine(Battle());
        }
    }

    public void OnStatsButton()
    {
        if (state == BattleState.FIGHT)
        {
            SceneManager.LoadScene("CombatStatsEditor"); 
        }
    }

    
    IEnumerator Battle()
    {
        //These if else statements bascially decide who attacks first while also making sure the othe entity gets to deal damage
        if (PlayerUnit.speed > EnemyUnit.speed || PlayerUnit.speed == EnemyUnit.speed)
        {
            //Turns buttons off so player cannot attack twice
            DisableButton();
            //Calls the Take Damage function in the Unit.cs script and assings it to bool isDead to check if enemy dies
            bool isDead = enemyUnit.TakeDamage(PlayerUnit.strength, EnemyUnit.defense);
            //Updates the UI display
            enemyHUD.SetHp(EnemyUnit.currentHealth);
            enemyHUD.SetHUD(enemyUnit);

            hitSound.Play();
            yield return new WaitForSeconds(2f);

            if (isDead)
            {
                state = BattleState.WON;
                EndBattle();
            }
            else
            {
                bool playerDead = playerUnit.TakeDamage(EnemyUnit.strength, PlayerUnit.defense);

                playerHUD.SetHp(PlayerUnit.currentHealth);
                playerHUD.SetHUD(playerUnit);
                hitSound.Play();
                yield return new WaitForSeconds(1f);
                if (playerDead)
                {
                    state = BattleState.LOST;
                    EndBattle();
                }
                else
                {
                    state = BattleState.FIGHT;
                    PlayerTurn();
                }
            }
        }
        else if (EnemyUnit.speed > PlayerUnit.speed)
        {
            DisableButton();
            bool isDead = playerUnit.TakeDamage(EnemyUnit.strength, PlayerUnit.defense);

            playerHUD.SetHp(PlayerUnit.currentHealth);
            playerHUD.SetHUD(playerUnit);

            hitSound.Play();
            yield return new WaitForSeconds(2f);

            if (isDead)
            {
                state = BattleState.LOST;
                EndBattle();
            }
            else
            {
                bool enemyDead = enemyUnit.TakeDamage(PlayerUnit.strength, EnemyUnit.defense);
                enemyHUD.SetHp(EnemyUnit.currentHealth);
                enemyHUD.SetHUD(enemyUnit);
                hitSound.Play();
                yield return new WaitForSeconds(1f);
                if (enemyDead)
                {
                    state = BattleState.WON;
                    EndBattle();
                }
                else
                {
                    state = BattleState.FIGHT;
                    PlayerTurn();
                }
            }
        }
    }


    private void EndBattle()
    {
        if (state == BattleState.WON)
        {
            TurnOffEnemy.bossFight++;
            PlayerManager.victoryCounter++;
            fightMusic.Stop();
            bossMusic.Stop();
            playingMusic = false;
            if (EnemyUnit.enemyNumber == 7)
            {
                SceneManager.LoadScene("GameWin");
            }
            else
            {
                SceneManager.LoadScene("Victory");
            }
        }
        else if (state == BattleState.LOST)
        {
            fightMusic.Stop();
            bossMusic.Stop();
            playingMusic = false;
            SceneManager.LoadScene("GameOver");
        }
    }

    public void DisableButton()
    {
        attackButton.SetActive(false);
        statsButton.SetActive(false);
        battleHUD.SetActive(false);
    }
}
