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
    // Start is called before the first frame update
    void Start()
    {
        sentences=new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text=dialogue.name;
        Debug.Log("Starting conversation with "+dialogue.name);
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



    void EndDialogue(){
         ChangeScene("Combat");
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public void ChangeScene(string sceneName)
    {
       SceneManager.LoadScene("Combat");
    }
}
