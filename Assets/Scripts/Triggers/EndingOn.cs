using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingOn : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Ending", LoadSceneMode.Single);
            GameManager.instance.mushroomCounter = 0;
        }
    }
}
