using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{ 
    //private Movable moveThis;
    [SerializeField] private MovableObject objectToMove;
    [SerializeField] private SpriteRenderer lever;
    private bool canInteract = false;
    private bool justClicked = false;
    private float waitFor = 1f;

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
            if (Input.GetAxisRaw("Interact") == 1 && !justClicked)
            {
                lever.flipX = true;
                objectToMove.Trigger();
                justClicked = true;
            }
        }

        if (justClicked)
        {
            WaitForMe(waitFor);
        }
        else
        {
            lever.flipX = false;
        }
    }




    private void WaitForMe(float time)
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            justClicked = false;
        }
    }
}
