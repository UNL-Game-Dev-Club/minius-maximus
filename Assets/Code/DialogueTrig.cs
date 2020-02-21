using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DialogueTrig : MonoBehaviour
{
    //Enemy set stats variables
    [SerializeField] int health;
    [SerializeField] int strength;
    [SerializeField] int defense;
    [SerializeField] int speed;
    [SerializeField] int enemyNumber;

    //UI for dialogue
    public GameObject button;
    public GameObject sierraMist;
    public SpriteRenderer sierraMistSprite;

    //Reference to dialoguemanager
    DialogueManager dialogueManager;

  
    
    private void Start()
    {
        sierraMistSprite = sierraMist.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        dialogueManager = FindObjectOfType<DialogueManager>();
        Debug.Log(button);
        HideButton();

    }

    //Checks if conversation is done and loads combat scene and sets back to false if true
    private void Update()
    {
        if (dialogueManager.isTrue)
        {
            dialogueManager.isTrue = false;
            Fight();
        }
    }

    private void HideButton()
    {
        sierraMistSprite.enabled=false;
        button.SetActive(false);
    }
    private void ShowButton()
    {
         sierraMistSprite.enabled=true;
        button.SetActive(true);
    }



    public Dialogue dialogue;
    // Start is called before the first frame update

    /*When the player collides with the enemies trigger collider
    the dialogue in DialogueManager.cs is started
    enemies static stats are set to the enemy stats vars at the top
    the players maxhealth adjusted
    the players stats before the combat begins is stored in the statBefore vars*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialogueManager.StartDialogue(dialogue);
        ShowButton();
        EnemyUnit.currentHealth = health;
        EnemyUnit.maxHealth = health;
        EnemyUnit.strength = strength;
        EnemyUnit.defense = defense;
        EnemyUnit.speed = speed;
        EnemyUnit.enemyNumber = enemyNumber;

        PlayerUnit.maxHealth = PlayerUnit.currentHealth;

        PlayerUnit.healthBefore = PlayerUnit.currentHealth;
        PlayerUnit.strengthBefore = PlayerUnit.strength;
        PlayerUnit.defenseBefore = PlayerUnit.defense;
        PlayerUnit.speedBefore = PlayerUnit.speed;
    }

    //Called when dialogue is finshed
    public void Fight()
    {

        SceneManager.LoadScene("Combat");
    }
}
