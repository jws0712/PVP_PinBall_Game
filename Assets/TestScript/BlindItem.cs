using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class BlindItem : MonoBehaviour
{
    WebSocket ws;
    public float xpos;
    public float ypos;
    public Vector2 newposition;
    public SetBlind AppearBlind;
    private void Start()
    {
        PosSet();
    }
    void PosSet()
    {
        xpos = Random.Range(-160, 160);
        ypos = Random.Range(-200, 270);
        newposition = new Vector2(xpos, ypos);
        transform.position = newposition;
    }

    // Update is called once per frame
    void Update()
    {
        //PosSet();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("Blind Active");
            AppearBlind.BlindSet();
            PosSet();
            
        }
        else if(collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Wall or Obstacle");
            PosSet();
        }
    }
}
