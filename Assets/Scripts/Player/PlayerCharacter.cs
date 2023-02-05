using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerCharacter : MonoBehaviour //Mover has update Animation function and sprite rotation
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
    [SerializeField] Collider2D sphereCollider;
    public bool isGrounded;
    protected Vector3 baseScale; //just for rotation
    protected Animator animator;
    private float moveButton;
    [SerializeField] private float maxSpeed = 7f;
    [HideInInspector]public bool inAir = false, isMoving = true;
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

    protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
        if (isMoving)
        {
            moveButton = Input.GetAxisRaw("Horizontal");
            Movement();
        }
        

        AnimationUpdate();
    }



    protected void Movement()
    {
        if (moveButton != 0) //during move
        {
            if (!inAir)
                rigidBody.AddForce(new Vector2(moveButton * movementAcceleration, 0), ForceMode2D.Impulse);
            else
            {
                rigidBody.AddForce(new Vector2(moveButton * movementAcceleration * airMovementForce, 0), ForceMode2D.Impulse);
            }
            rigidBody.velocity = new Vector3(Mathf.Clamp(rigidBody.velocity.x, -maxSpeed, maxSpeed), rigidBody.velocity.y, 0);
        }
        else //slow down if not in move
        {
            if (Mathf.Abs(rigidBody.velocity.x) < 1)
            {
                rigidBody.velocity = new Vector3(0, rigidBody.velocity.y, 0);
            }
            else
            {
                if (!inAir)
                    rigidBody.AddForce(new Vector2(-rigidBody.velocity.x * slowPower, 0), ForceMode2D.Impulse);
                else
                {
                    rigidBody.AddForce(new Vector2(-rigidBody.velocity.x * slowPower * airMovementForce, 0), ForceMode2D.Impulse);
                }
            }

        }
    }


    #region stay on platform
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            transform.parent = collision.transform;
        }
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Block")
        {
            isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
     if(collision.gameObject.tag == "Platform")
        {
            transform.parent = null;
        }
    }
    #endregion

    protected void Jump()
    {
       
        if (!inAir)
        {
            inAir = true;
            isGrounded = false;
            rigidBody.AddForce(new Vector2(0, jumpForce * 1), ForceMode2D.Impulse);
            

        }
    }



    protected virtual void AnimationUpdate()
    {

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


        if (inAir)
        {
            animator.SetBool("isGrounded", false);

            if (moveDelta.y > 0 && !isGrounded)
            { 
               
            animator.SetBool("isJumping", true);
            }
            else
            {
                
                animator.SetBool("isJumping", false);
            }
        }

        if(isGrounded)
        {
            animator.SetBool("isGrounded", true);
            Debug.Log("Grounded");
        }

    }
}
