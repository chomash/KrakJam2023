using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private Dialogue dialogueToStart;
    private bool canInteract = false;
    public bool autoInteract = false;


    private void Update()
    {
        if (canInteract && Input.GetKeyDown("e") && !GameManager.instance.inDialogue && !autoInteract)
        {
            GameManager.instance.inDialogue = true;
            TriggerDialogue();
        }
        
        if (canInteract && autoInteract && !GameManager.instance.inDialogue)
        {
            GameManager.instance.inDialogue = true;
            TriggerDialogue();
        }

        if (Input.GetKeyDown("e") && GameManager.instance.inDialogue && canInteract)
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
            canInteract = false;
        }
    }
    public void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogueToStart);
    }
}
