using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance { get; private set; }

    public TMP_Text spokenText;
    public GameObject avatar1, avatar2, dialogContainer;
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
        dialogContainer.SetActive(false);
        dialogueEntries = new Queue<DialogueEntry>();
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue) //pass dialogues
    {
        dialogContainer.SetActive(true);
        GameManager.instance.inDialogue = true;

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
        UpdateSpeaker(dialogueEntries.Peek().avatarName);
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


    private void UpdateSpeaker(string name)
    {
        foreach(AvatarEntry avatar in avatarList.avatarList)
        {
            if(avatar.avatarName == name)
            {
                if (avatar.isMain)
                {
                    avatar1.SetActive(true);
                    avatar2.SetActive(false);

                    avatar1.transform.Find("name").GetComponent<TMP_Text>().text = name;
                    avatar1.transform.Find("avatar").GetComponent<Image>().sprite = avatar.avatarImage;
                    return;
                }
                else
                {
                    avatar1.SetActive(false);
                    avatar2.SetActive(true);

                    avatar2.transform.Find("name").GetComponent<TMP_Text>().text = name;
                    avatar2.transform.Find("avatar").GetComponent<Image>().sprite = avatar.avatarImage;
                    return;
                }
            }
        }
    }

    private void EndDialogue()
    {
        dialogContainer.SetActive(false);
        GameManager.instance.inDialogue = false;

        Debug.Log("END");
    }

}
