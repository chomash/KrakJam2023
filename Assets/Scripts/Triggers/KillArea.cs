using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillArea : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("KillPlayer");
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.DamagePlayer();
        }
    }
}
