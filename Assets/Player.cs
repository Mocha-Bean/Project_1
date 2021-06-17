using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private int lives = 3;
    private int health = 2; // Mario can take two hits before he dies
    private Vector3 respawnPosition = new Vector3(-1.855f, 1.148f, 0);

    //Jumping
    public Rigidbody2D thisRigidBody;
    public bool jumpIsAvailable;
    public float jumpHeight;

    //Facing

    public enum Facing { left, right }
    public Facing facing;
    private SpriteRenderer thisSpriteRenderer;

    //------------------------
    // Functions
    //------------------------

    // Start is called before the first frame update
    void Start()
    {
        facing = Facing.left;
        thisSpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if(health <= 0)
        {
            //Respawn mario at the beginning of the level
            this.transform.position = respawnPosition;
            health = 2;
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
        }
        else if (isPushingRight)
        {
            newPosition += Vector3.right * speed;
            this.facing = Facing.left;
        }

        if (Input.GetKey(KeyCode.UpArrow))
            newPosition += Vector3.up * speed;
        else if (Input.GetKey(KeyCode.DownArrow))
            newPosition += Vector3.down * speed;

        // Jump Input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

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
    }

    // AKA "A hook"
    // Called when two things collide in collision engine
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var otherGameObject = collision.gameObject;

        //Check if other object is the ground
        bool isGround = otherGameObject.tag == "Ground";
        bool isLife = otherGameObject.tag == "OneUp";

        //If so, restore ability of object to jump
        if (isGround)
            jumpIsAvailable = true;

        if (isLife)
        {
            lives++;
            Destroy(otherGameObject);
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

