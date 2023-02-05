using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillArea : Collidable
{
    public SpriteRenderer spriteRenderer;
    protected override void OnCollide(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            ActivateScript();
        }
    }

    private void ActivateScript()
    {
        GameManager.instance.DamagePlayer();
    }
}
