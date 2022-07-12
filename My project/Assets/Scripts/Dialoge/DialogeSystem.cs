using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

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
    public Queue<DialogeType> dialogeType;
    public Queue<UnityEvent> dialogeEvents;
    DialogeType type;
    public GameObject triggerToErrase;

    void Start()
    {
        names = new Queue<string>();
        sentences = new Queue<string>();
        timeBetweenChar = new Queue<float>();
        dialogeType = new Queue<DialogeType>();
        dialogeEvents = new Queue<UnityEvent>();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    public void StartDialogue(Dialoge[] dialogue, GameObject player, GameObject trigger, bool a)
    {
        playerGO = player;
        playerGO.GetComponent<CharacterController2D>().state = PlayerState.CANTMOVE;
        animator.SetBool("IsOpen", true);
        if(a)   triggerToErrase = trigger;
        else triggerToErrase = null;

        for(int i = 0; i<dialogue.Length;i++)
        {
            if (dialogue[i].name == "MC") dialogue[i].name = levelManager.player.name;
            names.Enqueue(dialogue[i].name);
            sentences.Enqueue(dialogue[i].sentences);
            timeBetweenChar.Enqueue(dialogue[i].time);
            dialogeType.Enqueue(dialogue[i].type);
            if (dialogue[i].type == DialogeType.ACTION)
            {
                dialogeEvents.Enqueue(dialogue[i].dialogeEvent);
            }
        }
        
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        UnityEvent unityEvent;
        if (dialogeType.Count != 0) type = dialogeType.Dequeue();

        if (sentences.Count == 0)
        {
            if (type == DialogeType.ACTION)
            {
                unityEvent = dialogeEvents.Dequeue();
            }
            else unityEvent = null;

            EndDialogue(unityEvent);
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
    public void EndDialogue(UnityEvent eventtt)
    {
        if(eventtt != null) eventtt.Invoke();
        playerGO.GetComponent<CharacterController2D>().state = PlayerState.NORMAL;
        animator.SetBool("IsOpen", false);
        Destroy(triggerToErrase);
    }
}
