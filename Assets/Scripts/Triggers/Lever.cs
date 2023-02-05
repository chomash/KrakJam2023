 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Trigger
{ 
    //private Movable moveThis;
   [SerializeField]private MovableObject objectToMove;
    [SerializeField] private SpriteRenderer lever;
    protected override void DoTrigger()
    {
        if (Input.GetAxisRaw("Interact") == 1)
        {
            lever.flipX = true;
            objectToMove.Trigger();
        }
    }
}
