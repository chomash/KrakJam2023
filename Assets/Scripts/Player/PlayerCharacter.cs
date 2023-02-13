using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class PlayerCharacter : MonoBehaviour //Mover has update Animation function and sprite rotation
{
    #region variables
    protected CapsuleCollider2D capsuleCollider;
    protected Rigidbody2D rigidBody;
    protected Vector3 moveDelta;
    protected SpriteRenderer spriteRend;
    [SerializeField] protected float movementAcceleration = 0.7f;
    [SerializeField] protected float jumpForce = 10f;
    [SerializeField] protected float airMovementForce = 0.4f;
    [SerializeField] protected float slowPower = 0.2f;
    [SerializeField] private float maxSpeed = 5f;
    public bool canDoubleJump = false;
    private bool isGrounded, canJump, jumpPressed;
    public int additionalJump = 1;
    protected Vector3 baseScale; //just for rotation
    protected Animator animator;
    private float moveButton;

    #endregion





    protected void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        baseScale = transform.localScale;
    }

    protected void Update()
    {
        moveButton = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        AnimationUpdate();
    }


    protected void FixedUpdate()
    {
        if (!GameManager.instance.inDialogue)
        {

                Movement();
        }
        else if (GameManager.instance.inDialogue)
        {
            rigidBody.velocity = Vector3.zero;
        }
    }

    protected void Movement()
    {

        if (moveButton != 0)
        {
            if (isGrounded)
                rigidBody.AddForce(new Vector2(moveButton * movementAcceleration, 0), ForceMode2D.Impulse);
            else
            {
                rigidBody.AddForce(new Vector2(moveButton * movementAcceleration * airMovementForce, 0), ForceMode2D.Impulse);
            }
            rigidBody.velocity = new Vector3(Mathf.Clamp(rigidBody.velocity.x, -maxSpeed, maxSpeed), rigidBody.velocity.y, 0);
        }
        else //slow down, only grounded
        {
            if (Mathf.Abs(rigidBody.velocity.x) < 0.5f)
            {
                rigidBody.velocity = new Vector3(0, rigidBody.velocity.y, 0);
            }
            else
            {
                if (isGrounded)
                {
                    rigidBody.AddForce(new Vector2(-rigidBody.velocity.x * slowPower, 0), ForceMode2D.Impulse);
                }
            }
        }
    }
    protected void Jump()
    {
        if (canJump)
        {
            rigidBody.AddForce(new Vector2(0, jumpForce * 1), ForceMode2D.Impulse);
            canJump = false;
            additionalJump--;
        }
        else if (canDoubleJump && additionalJump > 0)
        {
            rigidBody.AddForce(new Vector2(0, jumpForce * 1), ForceMode2D.Impulse);
            additionalJump--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 2f);
        if (hit.collider.tag == "Platform" || collision.gameObject.tag == "Block")
        {
            isGrounded = true;
            canJump = true;
            additionalJump = 1;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            transform.parent = collision.transform;
        }
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 2f);
        if (hit.collider.tag == "Platform" || collision.gameObject.tag == "Block")
        {
            isGrounded = true;
            canJump = true;
            additionalJump = 1;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Block")
        {
            isGrounded = false;
            canJump = false;
        }
        if (collision.gameObject.tag == "Platform")
        {
            transform.parent = null;
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


        if (isGrounded)
        {
            animator.SetBool("isGrounded", true);
        }
        else
        {
            animator.SetBool("isGrounded", false);

        }


        if (moveDelta.y > 0 && !isGrounded)
        {        
        animator.SetBool("isJumping", true);
        }
        else
        {      
            animator.SetBool("isJumping", false);
        }

        


    }
}
