using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : Collidable
{
    private bool justClicked = false;
    protected override void OnCollide(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (Input.GetAxisRaw("Interact") == 1 && !justClicked)
            {
                justClicked = true;
                DoTrigger();
            }
            else if(Input.GetAxisRaw("Interact") == 0)
            {
                justClicked = false;
            }
        }
    }

    protected virtual void DoTrigger()
    {
        Debug.Log("Triggering me");
    }
}
