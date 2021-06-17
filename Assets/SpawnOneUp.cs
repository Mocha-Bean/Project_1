using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOneUp : MonoBehaviour
{

    public GameObject oneUpPrefab;
    public 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var other = collision.gameObject;

        if (other.GetComponent<Player>() != null)
        {
            var oneUp = GameObject.Instantiate(oneUpPrefab);
            oneUp.transform.position = this.transform.position + new Vector3(0, 0.5f, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
