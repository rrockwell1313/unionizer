using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdrianDialogue : MonoBehaviour
{
    [TextArea]
    public string[] allSignatures;
    [TextArea]
    public string[] enoughSignatures;
    [TextArea]
    public string[] notEnoughSignatures;
    public QuestTracker[] trackers;
    public float dialogueDelay = 1.3f;
    public GameObject panel;
    public Text dialogueText;

    string[] dialogueToDisplay;
    float timeAtStartOfScene;
    int dialogueIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        timeAtStartOfScene = Time.time;
        panel.SetActive(false);

        int count = 0;
        foreach (QuestTracker t in trackers)
        {
            if (t.reputation == Reputation.PLEASED)
            {
                count++;
            }
        }
        Debug.Log("count" + count);
        if (count == 7)
        {
            dialogueToDisplay = allSignatures;
        }
        else if (count >= 4)
        {
            dialogueToDisplay = enoughSignatures;
        }
        else
        {
            dialogueToDisplay = notEnoughSignatures;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timeAtStartOfScene + dialogueDelay < Time.time)
        {
            panel.SetActive(true);
            dialogueText.text = "Dave the dev: " + dialogueToDisplay[dialogueIndex];
            if (dialogueIndex < dialogueToDisplay.Length - 1)
                dialogueText.text += "\n(Press Space to continue...)";

            if (Input.GetKeyDown(KeyCode.Space) && dialogueIndex < dialogueToDisplay.Length - 1)
            {
                dialogueIndex++;
            }
        }
    }
}
