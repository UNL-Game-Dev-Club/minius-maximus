using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject player;

    public List<Transform> checkpoints;

    public static int victoryCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, checkpoints[victoryCounter]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
