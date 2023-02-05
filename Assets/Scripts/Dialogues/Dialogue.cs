using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Dialogue")]
public class Dialogue : ScriptableObject
{
    public DialogueEntry[] dialogue;
    
}


[System.Serializable]
public class DialogueEntry
{
    public string avatarName;

    [TextArea(2, 4)]
    public string[] sentences;
}
