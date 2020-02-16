using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DialogueTrig : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int strength;
    [SerializeField] int defense;
    [SerializeField] int enemyNumber;
    public GameObject button;
    public GameObject sierraMist;
    public SpriteRenderer sierraMistSprite;

    DialogueManager dialogueManager;

  

    private void Start()
    {
        //button = GameObject.Find("Button");
        //sierraMist = GameObject.Find("Sierra Mist");
        sierraMistSprite = sierraMist.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        dialogueManager = FindObjectOfType<DialogueManager>();
        Debug.Log(button);
        HideButton();
      
    }

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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialogueManager.StartDialogue(dialogue);
        ShowButton();
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
