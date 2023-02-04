using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerCharacter : Mover //Mover has update Animation function and sprite rotation
{
    private float moveButton, jumpButton;
    // private string JUMP_TAG = "JUMPY"; //tag for floor
    [SerializeField] private float maxSpeed = 7f;
    private bool inAir = false, isMoving = true/*, canJump = true*/;
    //private Trigger trigger;

    protected void FixedUpdate()
    {
        if (isMoving)
        {
            moveButton = Input.GetAxisRaw("Horizontal");
            jumpButton = Input.GetAxisRaw("Jump");
            Movement();
            Jump();
            if(rigidBody.velocity.y == 0) ///trzeba zmienic na raycasta lub cos innego, bo sie postac klei do sufitu
            {
                inAir = false;
            }
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
            rigidBody.AddForce(new Vector2(0, jumpForce * jumpButton), ForceMode2D.Impulse);
  
        }
    }


}
