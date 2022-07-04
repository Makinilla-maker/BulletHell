using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogeSystem : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialoge dialogue)
    {
        Debug.Log("Starting conv with" + dialogue.name);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentece in dialogue.sentences)
        {
            sentences.Enqueue(sentece);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence =  sentences.Dequeue();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.16f);
        }
    }
    public void EndDialogue()
    {
        Debug.Log("End of conversation");
    }
}
