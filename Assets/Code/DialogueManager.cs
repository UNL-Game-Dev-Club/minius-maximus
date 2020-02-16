using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public Text nameText;
    public Text dialogueText;

    public bool dialogueStarted;

    public bool isTrue = false;
    // Start is called before the first frame update
    void Start()
    {
        dialogueStarted=false;
        sentences=new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueStarted=true;
        nameText.text=dialogue.name;
        sentences.Clear();
        foreach(string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count==0)
        {
            EndDialogue();
            return;
        }
        string sentence=sentences.Dequeue();
        dialogueText.text=sentence;
        Debug.Log(sentence);

    }



    public bool EndDialogue(){
        isTrue = true;
        dialogueStarted = false;

        return true;
    }

    // Update is called once per frame
    void Update()
    {
         
    }

   
}
