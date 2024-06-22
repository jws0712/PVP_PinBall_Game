using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;


public class SetBlind : MonoBehaviour
{
    WebSocket ws;
    public float xpos;
    public float ypos;
    public Vector2 newposition;

    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void BlindSet()
    {
        gameObject.SetActive(true);
        newposition = new Vector2(0,0);
        transform.position = newposition;
        StartCoroutine(Co_Wait(5));
    }

    // Update is called once per frame
    void Update()
    {
    }

    

    private IEnumerator Co_Wait(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        gameObject.SetActive(false);
    }
}
