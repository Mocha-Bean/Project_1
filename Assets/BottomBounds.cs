using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomBounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Destroy(collision.gameObject);
        }
        else
        {
            collision.gameObject.transform.position = new Vector3(-1.855f, 1.148f, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
