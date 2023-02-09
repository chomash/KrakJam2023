using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private Dialogue dialogueToStart;
    private bool canInteract = false;
    private bool canSpeak = false;
    public bool autoInteract = false;


    private void Update()
    {
        if (GameManager.instance.inDialogue && canSpeak)
        {
            if (Input.GetButtonDown("Interact"))
            {
                DialogueManager.instance.NextSentence();
                Debug.Log("beep");
                if (DialogueManager.instance.dialogueEntries.Count == 0)
                {
                    Destroy(GetComponent<DialogueTrigger>());
                }
            }
        }
        else if (canInteract)
        {
            if (autoInteract)
            {
                GameManager.instance.inDialogue = true;
                canSpeak = true;
                TriggerDialogue();
                return;
            }
            else if (Input.GetAxisRaw("Interact") == 1)
            {
                GameManager.instance.inDialogue = true;
                canSpeak = true;
                TriggerDialogue();
                return;
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
