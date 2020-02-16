using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DialogueTrig : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int strength;
    [SerializeField] int defense;
    [SerializeField] int enemyNumber;

    DialogueManager dialogueManager;

  

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
      
    }

    private void Update()
    {
        if (dialogueManager.isTrue)
        {
            dialogueManager.isTrue = false;
            Fight();
        }
    }

    public Dialogue dialogue;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialogueManager.StartDialogue(dialogue);
        EnemyUnit.currentHealth = health;
        EnemyUnit.maxHealth = health;
        EnemyUnit.strength = strength;
        EnemyUnit.defense = defense;
        EnemyUnit.enemyNumber = enemyNumber;

        PlayerUnit.currentHealth = PlayerUnit.maxHealth;

    }


    public void Fight()
    {

        SceneManager.LoadScene("Combat");
    }
}
