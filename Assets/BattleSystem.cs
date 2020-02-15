using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    BattleState state;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
