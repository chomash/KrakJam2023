using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool inDialogue = false;
    [SerializeField] private GameObject inventory;
    public int mushroomCounter { get; private set; }
    void Awake()
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

    public void AddShroom(int i)
    {
        mushroomCounter += i;
    }

    public void Update()
    {
        if (!inDialogue) //open inventory
        {
            if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.I))
            {
                if (inventory.activeSelf)
                {
                    inventory.SetActive(false);
                }
                else
                {
                    inventory.SetActive(true);
                }
            }
        }
    }

}
