using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance { get; private set; }


    public Image avatarOne, avatarTwo;
    public  TMP_Text nameOne, nameTwo, spokenText;
    [SerializeField] private AvatarList avatarList;

    public Queue<DialogueEntry> dialogueEntries { get; private set; }
    private Queue<string> sentences;

    private void Awake() //singleton
    {
       if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        dialogueEntries = new Queue<DialogueEntry>();
        sentences = new Queue<string>();
    }


    public void StartDialogue(Dialogue dialogue) //pass dialogues
    {
        dialogueEntries.Clear();
        foreach(DialogueEntry dialogueEntry in dialogue.dialogue)
        {
            dialogueEntries.Enqueue(dialogueEntry);
        }
        NextDialogueEntry();
    }
    private void NextDialogueEntry()
    {
        sentences.Clear();
        //update avatar text
        foreach (string sentence in dialogueEntries.Peek().sentences)
        {
            sentences.Enqueue(sentence);
        }
        NextSentence();
    }

    public void NextSentence()
    {
        if(sentences.Count == 0)
        {
            dialogueEntries.Dequeue();
            if(dialogueEntries.Count == 0)
            {
                EndDialogue();
                return;
            }
            NextDialogueEntry();
            return;
        }
        else
        {
            string sentence = sentences.Dequeue();
            spokenText.text = sentence;
        }
    }


    private void UpdateAvatar(string name)
    {
        foreach(AvatarEntry avatar in avatarList.avatarList)
        {
            if(avatar.avatarName == name)
            {
                avatarTwo.sprite = avatar.avatarImage;
            }
            else
            {
                Debug.Log("Avatar NOT FOUND");
            }
        }
    }

    private void EndDialogue()
    {
        Debug.Log("END");
    }

}
