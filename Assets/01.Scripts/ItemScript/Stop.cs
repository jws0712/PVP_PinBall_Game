using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : MonoBehaviour
{

    public float xpos;
    public float ypos;
    public Vector2 newposition;
    public SetBlind AppearBlind;

    private void Start()
    {
        PosSet();
    }

    private void Update()
    {
        
    }

    void PosSet()
    {
        xpos = Random.Range(-160, 160);
        ypos = Random.Range(-200, 270);
        newposition = new Vector2(xpos, ypos);
        transform.position = newposition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            PosSet();
        }
        else if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Obstacle")
        {
            PosSet();
            Debug.Log("¥Í¿Ω");
        }
    }
}
