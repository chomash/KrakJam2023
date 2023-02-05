using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region
    public static GameManager instance { get; private set; }


    public FloatingTextManager floatingTextManager;
    [HideInInspector] public int nextSceneToLoad = 0;
    [HideInInspector] public bool inDialogue = false;
    [SerializeField] GameObject inventory;

    private SpawnPoint spawnPoint;
    

    public GameObject playerRef { get; private set; }
    public int mushroomCounter = 0;
    #endregion

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
    public void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
    }
    public void Update()
    {
        Debug.Log(inventory);
        if (!inDialogue) //open inventory
        {
            if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.I))
            {
                if (inventory.activeSelf.Equals(true))
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

    public void AddShroom(int i)
    {
        mushroomCounter += i;
    }

    public void SetSpawnPoint(SpawnPoint newSpawnPoint)
    {
        if (spawnPoint != null)
        {
            spawnPoint.DeactivateSpawn();
        }
        spawnPoint = newSpawnPoint;
    }

    public void DamagePlayer()
    {
        if(spawnPoint != null)
        {
            playerRef.transform.position = spawnPoint.transform.position+new Vector3(0,0.5f,0);
        }
        else Debug.Log("Respawn Point not found");

    }


    public void ShowE()
    {
        ShowText("<b>Wciœnij</b> E", 32, Color.white, playerRef.transform.position + new Vector3(0, 5f, 0), Vector3.zero, 3f);
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
