using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public int lives = 3;
    public int health = 1; // Mario can take one hit before he dies
    private Vector3 respawnPosition = new Vector3(-1.855f, 1.148f, 0);

    //Jumping
    public Rigidbody2D thisRigidBody;
    public bool jumpIsAvailable;
    public float jumpHeight;

    //Facing

    public enum Facing { left, right }
    public Facing facing;
    public bool MovingStatus;
    private SpriteRenderer thisSpriteRenderer;

    public Vector3 initialscale;
    public Vector3 location;
    private bool BigMario = false;
    public DeathScreen youdied;

    //------------------------
    // Functions
    //------------------------

    // Start is called before the first frame update
    void Start()
    {
        facing = Facing.left;
        thisSpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        initialscale = transform.localScale;
        BigMario = false;
        MovingStatus = false;
    }
    // Update is called once per frame
    
    void Update()
    {
        // Jump Input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    
    void FixedUpdate()
    {
        if(health <= 0)
        {
            //Respawn mario at the beginning of the level
            transform.localScale = initialscale;
            BigMario = false;
            this.transform.position = respawnPosition;
            health = 1;
        }

        if(BigMario & health == 1) // did we take damage as big mario? reset size
        {
            transform.localScale = initialscale;
            BigMario = false;
        }

        //Get left or right arrow key input
        bool isPushingLeft = Input.GetKey(KeyCode.A);
        bool isPushingRight = Input.GetKey(KeyCode.D);

        Vector3 currentPosition = this.gameObject.transform.position;
        Vector3 newPosition = currentPosition;

        // Move player in accordance with input
        if (isPushingLeft)
        {
            newPosition += Vector3.left * speed;
            this.facing = Facing.right;
            MovingStatus = true;
        }
        else if (isPushingRight)
        {
            newPosition += Vector3.right * speed;
            this.facing = Facing.left;
            MovingStatus = true;
        } else
        {
            MovingStatus = false;
        }

        if (Input.GetKey(KeyCode.UpArrow))
            newPosition += Vector3.up * speed;
        else if (Input.GetKey(KeyCode.DownArrow))
            newPosition += Vector3.down * speed;

        // Update which way we are facing
        if (this.facing == Facing.left)
        {
            thisSpriteRenderer.flipX = false;
        }
        else
        {
            thisSpriteRenderer.flipX = true;
        }

        this.gameObject.transform.position = newPosition;
        location = transform.position;
    }

    // AKA "A hook"
    // Called when two things collide in collision engine
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var otherGameObject = collision.gameObject;

        //Check if other object is the ground
        bool isGround = otherGameObject.tag == "Ground";
        bool isLife = otherGameObject.tag == "OneUp";
        bool isBullet = otherGameObject.tag == "bullet";

        //If so, restore ability of object to jump
        if (isGround)
            jumpIsAvailable = true;

        if (isLife)
        {
            if (!BigMario)
            {
                health++;
                BigMario = true;
            }
            Destroy(otherGameObject);
            transform.localScale = transform.localScale * 1.5f;
        }

        if (isBullet)
        {
            health--;
            Destroy(otherGameObject);
            if(health == 0)
            {
                youdied.Trigger(); // triggers death screen
            }
        }
    }

    //
    // Utility Functions:
    //

    public int getLives()
    {
        return lives;
    }

    void Jump()
    {
        if (jumpIsAvailable)
        {
            //Sanity Check
            var forceToJump = Mathf.Sqrt(2 * jumpHeight * Mathf.Abs(this.thisRigidBody.gravityScale * Physics2D.gravity.y));
            thisRigidBody.velocity = new Vector2(thisRigidBody.velocity.x, forceToJump);
            this.jumpIsAvailable = false;
        }
    }

}

