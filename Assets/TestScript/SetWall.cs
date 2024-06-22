using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;


public class SetWall : MonoBehaviour
{
    WebSocket ws;
    public float xpos;
    public float ypos;
    public Vector2 newposition;

    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void WallSet()
    {
        gameObject.SetActive(true);
        xpos = Random.Range(-160, 160);
        ypos = Random.Range(-215, 270);
        newposition = new Vector2(xpos, ypos);
        transform.position = newposition;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            Debug.Log("Wall contact Ball");
            StartCoroutine(Co_Wait(0.2f));
            
        }
        else if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Wall or Obstacle");
            WallSet();
        }
    }

    private IEnumerator Co_Wait(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        gameObject.SetActive(false);
    }
}
