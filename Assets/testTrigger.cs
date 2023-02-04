using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testTrigger : MonoBehaviour
{
    //DialogueManager dialogeManager = DialogueManager.instance;
    [SerializeField] private Dialogue dialogueToStart;
    private bool active = true;

    public void Update()
    {
        if(Input.GetKeyUp("e"))
        {
            DialogueManager.instance.NextSentence();
            if(DialogueManager.instance.dialogueEntries.Count == 0)
            {
                active = false;
            }
        }
        if (!active)
        {
            Destroy(gameObject);
        }
    }
    public void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogueToStart);
    }


}
