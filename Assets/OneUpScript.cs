using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneUpScript : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //1up sprite moves right
        Vector3 currentPosition = this.gameObject.transform.position;

        currentPosition += Vector3.right * speed;

        this.gameObject.transform.position = currentPosition;

    }
}
