using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogeSystem : MonoBehaviour
{
    public GameObject playerGO;
    public LevelManager levelManager;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Queue<string> names;
    public Queue<string> sentences;
    public Queue<float> timeBetweenChar;
    public Animator animator;

    void Start()
    {
        names = new Queue<string>();
        sentences = new Queue<string>();
        timeBetweenChar = new Queue<float>();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    public void StartDialogue(Dialoge[] dialogue, GameObject player)
    {
        playerGO = player;
        playerGO.GetComponent<CharacterController2D>().state = PlayerState.CANTMOVE;
        animator.SetBool("IsOpen", true);

        for(int i = 0; i<dialogue.Length;i++)
        {
            if (dialogue[i].name == "MC") dialogue[i].name = levelManager.player.name;
            names.Enqueue(dialogue[i].name);
            sentences.Enqueue(dialogue[i].sentences);
            timeBetweenChar.Enqueue(dialogue[i].time);
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

        nameText.text = names.Dequeue();
        string sentence =  sentences.Dequeue();
        float time = timeBetweenChar.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence, time));
    }
    IEnumerator TypeSentence(string sentence, float time)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(time);
        }
    }
    public void EndDialogue()
    {
        playerGO.GetComponent<CharacterController2D>().state = PlayerState.NORMAL;
        animator.SetBool("IsOpen", false);
    }
}
