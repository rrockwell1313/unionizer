using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject panel;
    public float delayDuration = 2.0f;
    public Text dialogueText;
    public Dialogue greetDialogue;
    public BoolValue hasMet;
    public Dialogue irritatedDialogue;
    public Dialogue angryDialogue;
    public Dialogue pleasedDialogue;
    [Header("Data from Scriptable Objects")]
    public ReputationCounter counter;
    public Quest myQuest;
    public QuestLog log;

    Dialogue currentlyDisplayedText;
    float timeAtStartOfScene;
    bool delayedDialogue = false;
    // Start is called before the first frame update
    void Start()
    {
        hasMet.value = false;
        panel.SetActive(false);
        timeAtStartOfScene = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!delayedDialogue && timeAtStartOfScene + delayDuration > Time.time)
        {
            delayedDialogue = true;
            GenerateDialogue();
        }
    }

    public void GenerateDialogue()
    {
        panel.SetActive(true);
        if (!hasMet.value)
        {
            hasMet.value = true;
            DisplayDialogue(greetDialogue);
        }
        else
        {
            Reputation rep = counter.GetReputation();
            bool hasQuest = log.HasQuest(myQuest);
            if (rep == Reputation.PLEASED)
            {
                DisplayDialogue(pleasedDialogue);
            }
            else if (hasQuest)
            {
                if (rep != Reputation.ANGRY)
                {
                    DisplayDialogue(irritatedDialogue);
                }
                else
                {
                    DisplayDialogue(angryDialogue);
                }
            }
            else
            {
                dialogueText.text = greetDialogue.characterName + ": Hey, how's it going?";
            }
        }

        if (HasNextDialogue() && Input.anyKeyDown)
        {
            NextDialogue();
        }
    }

    public void DisplayDialogue(Dialogue dialogue)
    {
        currentlyDisplayedText = dialogue;
        dialogueText.text = currentlyDisplayedText.characterName + ": " + currentlyDisplayedText.dialogueText;
    }

    public void NextDialogue()
    {
        Dialogue next = currentlyDisplayedText.nextDialogue;
        DisplayDialogue(next);
    }

    public bool HasNextDialogue()
    {
        if (currentlyDisplayedText.nextDialogue != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
