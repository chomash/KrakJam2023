using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPoint : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
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
