using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UnitHUD : MonoBehaviour
{
    public Slider hpSlider;
    public Text playerHpText;
    public Text enemyHpText;

    public Text strengthText;
    public Text defenseText;
    public Text speedText;
    

    public void SetHUD(PlayerUnit playerUnit)
    {
        hpSlider.maxValue = PlayerUnit.maxHealth;
        hpSlider.value = PlayerUnit.currentHealth;

        strengthText.text = ": " + PlayerUnit.strength;
        defenseText.text = ": " + PlayerUnit.defense;
        speedText.text = ": " + PlayerUnit.speed;

        if (PlayerUnit.currentHealth <= 0)
        {
            playerHpText.text = "   0 / " + PlayerUnit.maxHealth;
        }
        else
        {
            playerHpText.text = "   " + PlayerUnit.currentHealth + " / " + PlayerUnit.maxHealth;
        }
    }

    public void SetHUD(EnemyUnit enemyUnit)
    {
        hpSlider.maxValue = EnemyUnit.maxHealth;
        hpSlider.value = EnemyUnit.currentHealth;

        strengthText.text = ": " + EnemyUnit.strength;
        defenseText.text = ": " + EnemyUnit.defense;
        speedText.text = ": " + EnemyUnit.speed;

        if (EnemyUnit.currentHealth <= 0)
        {
            enemyHpText.text = "   0 / " + EnemyUnit.maxHealth;
        }
        else
        {
            enemyHpText.text = "   " + EnemyUnit.currentHealth + " / " + EnemyUnit.maxHealth;
        }
    }
    

    public void SetHp(int hp)
    {
        hpSlider.value = hp;
    }

}
