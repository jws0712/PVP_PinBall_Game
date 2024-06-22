using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class BlindItem : MonoBehaviour
{
    WebSocket ws;

    [SerializeField] private GameObject apperBlind = null;

    private void Start()
    {
        ws = new WebSocket("ws://0.tcp.jp.ngrok.io:10138");
        //서버에서 설정한 포트를 넣어줍니다.

        ws.OnMessage += (sender, e) =>
        {
            Debug.Log("Message from server: " + e.Data);
        };

        ws.OnError += (sender, e) =>
        {
            Debug.LogError("Error: " + e.Message);
        };

        ws.Connect();

        ws.OnMessage += Call;
    }

    void Call(object sender, MessageEventArgs e)
    {
        Debug.Log("주소 :  " + ((WebSocket)sender).Url + ", 데이터 : " + e.Data);
    }

    public void BlindSet()
    {
        Instantiate(apperBlind, Vector3.zero, Quaternion.identity);
        transform.position = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            BlindSet();
            ws.Send("type: item," + "item: " + gameObject.name + "," + "x: " + transform.position.x + "," + "y: " + transform.position.y);
            Destroy(gameObject);
            GameManager.Instance.isOnItem = false;
        }
    }
}
