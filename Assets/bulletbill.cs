using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletbill : MonoBehaviour
{
    public Player mario;
    public Rigidbody2D rb;
    public float speed;
    public float predictDist;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        Vector3 diff = mario.location - transform.position;
        if(mario.MovingStatus & mario.facing == Player.Facing.left) // is mario actively moving, and facing right? (mario's Facing is backwards lol)
        {
            diff += (Vector3.right * predictDist);
        } else if (mario.MovingStatus & mario.facing == Player.Facing.right) // left?
        {
            diff += (Vector3.left * predictDist);
        }
        diff.Normalize();
        float angle = Mathf.Atan2(diff.y, diff.x);
        transform.rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg);

        rb.AddForce(diff * speed);
    }
}
