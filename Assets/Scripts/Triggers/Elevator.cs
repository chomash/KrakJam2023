using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Elevator : Trigger
{
    [SerializeField] public int nextSceneToLoadID;
    protected override void DoTrigger()
    {
        if (Input.GetAxisRaw("Interact") == 1)
        {
            //do something
            SceneManager.LoadScene("SceneLoader");
            GameManager.instance.nextSceneToLoad = nextSceneToLoadID;

        }
    }
}
