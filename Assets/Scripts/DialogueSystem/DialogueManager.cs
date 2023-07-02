using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public string characterName;
    public GameObject panel;
    public float delayDuration = 2.0f;
    public Text dialogueText;
    public QuestTracker myTracker;
    public QuestTracker recipientTracker;
    [TextArea]
    public string[] receiveDialogue;

    float timeAtStartOfScene;
    bool delayedDialogue = false;
    int countDialogue = 0;
    string[] currentDialogue;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        timeAtStartOfScene = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if (timeAtStartOfScene + delayDuration < Time.time)
        {
            if (!delayedDialogue)
            {
                delayedDialogue = true;
                GenerateDialogue();
            }

            if (HasNextDialogue(currentDialogue) && Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Triggering next dialogue");
                countDialogue++;
                DisplayDialogue(currentDialogue);
                if (characterName == "Dulcinea" || characterName == "Amelie" || characterName == "Priscilla")
                {            
                    SFXManager.Instance.PlaySound("FemaleHmm0" + Random.Range(0, 6));
                    Debug.Log("It's working in the lady office");
                }
                else
                {
                    SFXManager.Instance.PlaySound("MaleHmm0" + Random.Range(0, 6));
                    Debug.Log("It's working in the lady office");
                }
            }
        }        
    }

    public void GenerateDialogue()
    {
        panel.SetActive(true);
        if (recipientTracker?.questStatus == QuestStatus.ASSIGNED)
        {
            currentDialogue = AssembleNewDialogue(receiveDialogue, myTracker.GetDialogue());
            recipientTracker.questStatus = QuestStatus.COMPLETED;
        }
        else
        {
            currentDialogue = myTracker.GetDialogue();
        }

        DisplayDialogue(currentDialogue);
    }

    public void DisplayDialogue(string[] dialogue)
    {
        dialogueText.text = characterName + ": " + dialogue[countDialogue];
        if (HasNextDialogue(dialogue))
        {
            dialogueText.text += "\n(Press Space to continue...)";
        }
    }

    public bool HasNextDialogue(string[] dialogue)
    {
        if (dialogue.Length > countDialogue + 1)
        {
            Debug.Log("Has text");
            return true;
        }
        else
        {
            Debug.Log("No Has text");
            return false;
        }
    }

    string[] AssembleNewDialogue(string[] a, string[] b)
    {
        string[] c = new string[a.Length + b.Length];

        a.CopyTo(c, 0);
        b.CopyTo(c, a.Length);

        return c;
    }
}
