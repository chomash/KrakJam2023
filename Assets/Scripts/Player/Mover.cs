using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    #region variables
    protected CapsuleCollider2D capsuleCollider;
    protected Rigidbody2D rigidBody;
    protected Vector3 moveDelta;
    protected SpriteRenderer spriteRend;
    [SerializeField] protected float movementAcceleration = 0.7f;
    [SerializeField] protected float jumpForce = 7f;
    [SerializeField] protected float airMovementForce = 0.3f;
    [SerializeField] protected float slowPower = 0.2f;
    protected Vector3 baseScale; //just for rotation
    protected Animator animator;
    #endregion

    protected void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        baseScale = transform.localScale;
        Debug.Log("name");
    }

    protected virtual void AnimationUpdate()
    {
        //set move delta, change animation based on it
        moveDelta = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, 0);

        if (moveDelta.x != 0) //walking/moving direction update
        {
            if (moveDelta.x > 0)
                transform.localScale = new Vector3(baseScale.x, baseScale.y, baseScale.z);
            else if (moveDelta.x < 0)
                transform.localScale = new Vector3(-baseScale.x, baseScale.y, baseScale.z);
            
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (moveDelta.y == 0) //jumping/walking update
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
        }

        if (moveDelta.y > 0.1)
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("isFalling", false);
        }

        if (moveDelta.y < 0.1)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", true);
            Debug.Log("true spada");
        }

    }

}
