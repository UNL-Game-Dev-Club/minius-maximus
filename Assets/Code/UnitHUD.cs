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

        playerHpText.text = "   " + PlayerUnit.currentHealth + " / " + PlayerUnit.maxHealth;
        strengthText.text = ": " + PlayerUnit.strength;
        defenseText.text = ": " + PlayerUnit.defense;
        speedText.text = ": " + PlayerUnit.speed;
    }

    public void SetHUD(EnemyUnit enemyUnit)
    {
        hpSlider.maxValue = EnemyUnit.maxHealth;
        hpSlider.value = EnemyUnit.currentHealth;

        enemyHpText.text = "Hp " + EnemyUnit.currentHealth + " / " + EnemyUnit.maxHealth;
        strengthText.text = ": " + EnemyUnit.strength;
        defenseText.text = ": " + EnemyUnit.defense;
        speedText.text = ": " + EnemyUnit.speed;
    }

    public void SetHp(int hp)
    {
        hpSlider.value = hp;
    }

}
