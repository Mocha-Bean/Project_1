using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnbill : MonoBehaviour
{
    public GameObject bulletbill;
    bulletbill bullet;
    public Player mario;

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
            var bill = GameObject.Instantiate(bulletbill);
            bullet = bill.GetComponent<bulletbill>();
            bullet.mario = mario;
            bill.transform.position = this.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
