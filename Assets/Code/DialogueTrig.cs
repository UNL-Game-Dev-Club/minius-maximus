using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrig : MonoBehaviour
{
    public Dialogue dialogue;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
       FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

        
    }
}
