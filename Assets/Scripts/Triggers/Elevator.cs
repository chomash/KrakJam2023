using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Elevator : MonoBehaviour
{
    [SerializeField] public int nextSceneToLoadID;
    private bool canInteract;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.tag == "Player")
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("NotCollided");
        if (collision.gameObject.tag == "Player")
        {
            canInteract = false;
        }
    }

    private void Update()
    {
        if (canInteract)
        {
            if (Input.GetAxisRaw("Interact") == 1)
            {
                SceneManager.LoadScene("SceneLoader");
                GameManager.instance.nextSceneToLoad = nextSceneToLoadID;
            }
        }
    }
}
