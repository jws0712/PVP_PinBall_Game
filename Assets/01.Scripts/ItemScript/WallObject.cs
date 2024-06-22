using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallObject : MonoBehaviour
{
    private float xpos;
    private float ypos;
    private Vector2 newposition;

    private void Start()
    {
        WallSet();
    }
    public void WallSet()
    {
        xpos = Random.Range(-160, 160);
        ypos = Random.Range(-215, 270);
        newposition = new Vector2(xpos, ypos);
        transform.position = newposition;
    }

    private IEnumerator Co_Wait(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            StartCoroutine(Co_Wait(0.2f));
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Obstacle")
        {
            WallSet();
        }
    }
}
