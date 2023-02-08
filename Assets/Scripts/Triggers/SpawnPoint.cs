using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : Collidable
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
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
        animator.SetBool("isActive", true);

    }

    public void DeactivateSpawn()
    {
        animator.SetBool("isActive", false);

    }
}
