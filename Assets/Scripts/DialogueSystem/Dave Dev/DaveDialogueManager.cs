using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DaveDialogueManager : MonoBehaviour
{
    public Dialogue[] dialogues;
    public float dialogueDelay = 1.3f;
    public GameObject panel;
    public Text dialogueText;

    float timeAtStartOfScene;
    int dialogueIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        timeAtStartOfScene = Time.time;
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeAtStartOfScene + dialogueDelay < Time.time)
        {
            panel.SetActive(true);
            dialogueText.text = dialogues[dialogueIndex].characterName + ": " + dialogues[dialogueIndex].dialogueText;
            if (dialogueIndex < dialogues.Length - 1)
                dialogueText.text += "\n(Press Space to continue...)";

            if (Input.GetKeyDown(KeyCode.Space))
            {
                dialogueIndex++;
            }
        }
    }
}
