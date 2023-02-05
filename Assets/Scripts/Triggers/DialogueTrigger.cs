using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private Dialogue dialogueToStart;
    private bool canInteract;


    private void Update()
    {
        if (canInteract && Input.GetKeyUp("e") && !GameManager.instance.inDialogue)
        {
            TriggerDialogue();
            GameManager.instance.inDialogue = true;
        }
        if(Input.GetKeyDown("e") && GameManager.instance.inDialogue)
        {
            DialogueManager.instance.NextSentence();
            if(DialogueManager.instance.dialogueEntries.Count == 0)
            {
                Destroy(GetComponent<DialogueTrigger>());
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canInteract = true;
        }
    }
    public void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogueToStart);
    }
}
