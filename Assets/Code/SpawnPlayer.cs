using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject playerPrefab;

    public Transform playerPlatform;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(playerPrefab, playerPlatform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
