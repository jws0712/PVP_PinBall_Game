using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class StopBall : MonoBehaviour
{
    private GameObject ball = null;

    WebSocket ws;

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

    private void Update()
    {
        ball = GameObject.FindWithTag("Ball");
    }


    //주요기능을 실행하는 함수
    private void LoackBall()
    {
        StartCoroutine(Co_Stop());
    }

    //아이템의 주요 기능을 실행
    private IEnumerator Co_Stop()
    {
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        yield return new WaitForSeconds(0.1f);
    }

    //충돌이벤트
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            LoackBall();
            ws.Send("type: item," + "item: " + gameObject.name + "," + "x: " + transform.position.x + "," + "y: " + transform.position.y);
            Destroy(gameObject);
            GameManager.Instance.isOnItem = false;
        }
    }
}
