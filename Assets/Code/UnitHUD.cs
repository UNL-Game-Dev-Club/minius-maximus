using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UnitHUD : MonoBehaviour
{
    public Slider hpSlider;

    public void SetHUD(PlayerUnit playerUnit)
    {
        hpSlider.maxValue = PlayerUnit.maxHealth;
        hpSlider.value = PlayerUnit.currentHealth;
    }

    public void SetHUD(EnemyUnit enemyUnit)
    {
        hpSlider.maxValue = EnemyUnit.maxHealth;
        hpSlider.value = EnemyUnit.currentHealth;
    }

    public void SetHp(int hp)
    {
        hpSlider.value = hp;
    }

}
