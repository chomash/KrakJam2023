using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
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
        Debug.Log("Current Shroom Counter: " + mushroomCounter);
        //update UI
    }


}
