using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UnitHUD : MonoBehaviour
{
    public Slider hpSlider;

    public Text playerHpText;
    public Text enemyHpText;

    public void SetHUD(PlayerUnit playerUnit)
    {
        hpSlider.maxValue = PlayerUnit.maxHealth;
        hpSlider.value = PlayerUnit.currentHealth;
        playerHpText.text = "Hp: " + PlayerUnit.currentHealth + " / " + PlayerUnit.maxHealth;
    }

    public void SetHUD(EnemyUnit enemyUnit)
    {
        hpSlider.maxValue = EnemyUnit.maxHealth;
        hpSlider.value = EnemyUnit.currentHealth;
        enemyHpText.text = "Hp: " + EnemyUnit.currentHealth + " / " + EnemyUnit.maxHealth;
    }

    public void SetHp(int hp)
    {
        hpSlider.value = hp;
    }

}
