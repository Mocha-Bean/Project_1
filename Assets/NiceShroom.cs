using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NiceShroom : MonoBehaviour
{
    public float speed;
    public Player mario;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 dir = mario.location - transform.position;
        dir = new Vector3(dir.x, 0, 0);
        dir.Normalize(); // horizontal vector pointing towards mario; will be either (1, 0, 0) or (-1, 0, 0)

        Vector3 currentPosition = this.gameObject.transform.position;

        currentPosition += dir * speed;

        this.gameObject.transform.position = currentPosition;
    }
}
