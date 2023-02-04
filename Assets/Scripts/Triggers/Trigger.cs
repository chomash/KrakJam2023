using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : Collidable
{
    protected override void OnCollide(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            DoTrigger();
        }
    }

    protected virtual void DoTrigger()
    {
        Debug.Log("Triggering me");
    }
}
