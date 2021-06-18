using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOneUp : MonoBehaviour
{

    public GameObject oneUpPrefab;
    public GameObject NiceShroomPrefab;
    public Player mario;
    public bool NiceMushroom;
    private NiceShroom shroom;

    // Start is called before the first frame update
    void Start()
    {
        NiceMushroom = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var other = collision.gameObject;

        if (other.GetComponent<Player>() != null)
        {
            if (!NiceMushroom)
            {
                var oneUp = GameObject.Instantiate(oneUpPrefab);
                oneUp.transform.position = this.transform.position + new Vector3(0, 0.5f, 0);
            }
            else
            {
                var NiceShroom = GameObject.Instantiate(NiceShroomPrefab);
                shroom = NiceShroom.GetComponent<NiceShroom>();
                shroom.mario = mario;
                NiceShroom.transform.position = this.transform.position + new Vector3(0, 0.5f, 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // toggle between  evil mushroom and nice mushroom, to demonstrate design change
    public void ToggleNiceMushroom()
    {
        NiceMushroom = !NiceMushroom;
    }
}
