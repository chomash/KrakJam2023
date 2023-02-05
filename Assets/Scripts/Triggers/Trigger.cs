using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : Collidable
{
    private bool justClicked = false;
    private bool canShow = true;
    protected override void OnCollide(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            ShowE();
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

    private void ShowE()
    {
        if (canShow)
        {
            canShow = false;
            //GameManager.instance.ShowE();
        }

    }
    protected virtual void DoTrigger()
    {
        Debug.Log("Triggering me");
    }
}
