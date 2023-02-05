using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : Collidable
{
    public SpriteRenderer spriteRenderer;
    public Color active, deactive;
    protected override void OnCollide(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            ActivateSpawn();
        }
    }

    public void ActivateSpawn()
    {
        GameManager.instance.SetSpawnPoint(this);
        spriteRenderer.color = active;

    }

    public void DeactivateSpawn()
    {
        spriteRenderer.color = deactive;
    }
}
