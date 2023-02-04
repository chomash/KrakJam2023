using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhatUnderPlayer : Collidable
{
    [SerializeField] private PlayerCharacter player;
    protected override void OnCollide(Collider2D collider)
    {
            if (collider.CompareTag("Block") ||
                collider.CompareTag("Platform"))
                {
                    player.inAir = false;
                    player.isGrounded = true;
                } 
    }
}
