using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    public SpriteRenderer sr;

    private Color tmpcolor;
    private IEnumerator coroutine;
    
    // Start is called before the first frame update
    void Start()
    {
        tmpcolor = sr.color;
        tmpcolor.a = 0;
        sr.color = tmpcolor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Trigger()
    {
        coroutine = FadeIn();
        StartCoroutine(coroutine);
    }

    private IEnumerator FadeIn()
    {
        while(tmpcolor.a < 1)
        {
            tmpcolor.a += 0.02f;
            sr.color = tmpcolor;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        while (tmpcolor.a > 0)
        {
            tmpcolor.a -= 0.05f;
            sr.color = tmpcolor;
            yield return new WaitForSeconds(0.02f);
        }
    }
}
