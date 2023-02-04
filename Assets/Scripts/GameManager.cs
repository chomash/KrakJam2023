using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public FloatingTextManager floatingTextManager;
    private bool inDialogue = false;
    [SerializeField] private GameObject inventory;
    public GameObject playerRef { get; private set; }
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
    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
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

    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }
    public void ShowText()
    {
        floatingTextManager.Show("notImplemented", 24, Color.red, playerRef.transform.position + new Vector3(0,3f,0), new Vector3(0, 1f, 0), 2f);
    }
}
