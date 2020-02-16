using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffEnemy : MonoBehaviour
{
    public List<BoxCollider2D> enemyCollider;

    public List<DialogueTrig> enemyFight;

    public static int bossFight = 0;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < bossFight; i++)
        {
            Destroy(enemyCollider[i]) ;
        }
    }
}
