using System.Collections;using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue System/Dialogue")]
public class Dialogue : ScriptableObject
{
    public string characterName;
    [TextArea]
    public string dialogueText;
    public DialogueOption[] options;
}

[CreateAssetMenu(fileName = "New Option", menuName = "Dialogue System/Dialogue Option")]
public class DialogueOption : ScriptableObject
{
    [TextArea]
    public string responseText;
    public Dialogue nextDialogue;
}
