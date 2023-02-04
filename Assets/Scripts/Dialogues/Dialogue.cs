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
    public string nameKey;

    [TextArea(2, 3)]
    public string[] sentences;
}
