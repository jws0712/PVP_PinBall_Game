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
        //�������� ������ ��Ʈ�� �־��ݴϴ�.

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
        Debug.Log("�ּ� :  " + ((WebSocket)sender).Url + ", ������ : " + e.Data);
    }

    private void Update()
    {
        ball = GameObject.FindWithTag("Ball");
    }


    //�ֿ����� �����ϴ� �Լ�
    private void LoackBall()
    {
        StartCoroutine(Co_Stop());
    }

    //�������� �ֿ� ����� ����
    private IEnumerator Co_Stop()
    {
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        yield return new WaitForSeconds(0.1f);
    }

    //�浹�̺�Ʈ
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
