using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhatUnderPlayer : Collidable
{
    [SerializeField] private PlayerCharacter player;
    private bool canJumpAgain = true;
    protected override void OnCollide(Collider2D collider)
    {
        if (canJumpAgain)
        {
            if (collider.CompareTag("Block") ||
                collider.CompareTag("Platform"))
                {
                    player.inAir = false;
                    player.isGrounded = true;
                }
        }

        if (player.GetComponent<Rigidbody2D>().velocity.y < 0) ///jesli zacznie opadac, to moze próbê skoku
        {
            canJumpAgain = true;
        }        
    }
}
