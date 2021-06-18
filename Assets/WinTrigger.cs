using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public DeathScreen youwin; // win screen uses the same script as death screen
    public SpawnOneUp shroomspawn;
    public Player mario;
    private IEnumerator coroutine;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        youwin.Trigger();
        if(shroomspawn.NiceMushroom == true)
        {
            shroomspawn.ToggleNiceMushroom();
        }
        coroutine = RespawnDelay();
        StartCoroutine(coroutine);
    }

    private IEnumerator RespawnDelay()
    {
        yield return new WaitForSeconds(2f);
        mario.health = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
