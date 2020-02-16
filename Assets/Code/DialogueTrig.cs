using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DialogueTrig : MonoBehaviour
{
    public int health;
    public int strength;
    public int defense;
    public int enemyNumber;

    DialogueManager dialogueManager;

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
      
    }

    private void Update()
    {
        if (dialogueManager.isTrue)
        {
            Fight();
        }
    }

    public Dialogue dialogue;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

    }


    public void Fight()
    {
        EnemyUnit.currentHealth = health;
        EnemyUnit.maxHealth = health;
        EnemyUnit.strength = strength;
        EnemyUnit.defense = defense;
        EnemyUnit.enemyNumber = enemyNumber;

        PlayerUnit.currentHealth = PlayerUnit.maxHealth;



        SceneManager.LoadScene("Combat");
    }
}
