using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialTrigger : MonoBehaviour
{
    [SerializeField] GameObject TutWindow;
    [SerializeField] GameObject Player;

    private void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.tag == "Player")
        {
            TutWindow.SetActive(true);

            Player.GetComponent<PlayerCharacter>().enabled = false;
            Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            Player.GetComponent<Animator>().SetBool("isWalking", false);
        }
    }

    public void PlayerMovement()
    {
        Player.GetComponent<PlayerCharacter>().enabled = true;
        Destroy(this);
    }
}
