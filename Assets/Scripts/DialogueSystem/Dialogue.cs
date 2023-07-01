using System.Collections;using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue System/Dialogue")]
public class Dialogue : ScriptableObject
{
    public string emote; // make it bold and italics. 
    public string characterName;
    [TextArea(5, 20)]
    public string dialogueText;
    public Dialogue nextDialogue;
}