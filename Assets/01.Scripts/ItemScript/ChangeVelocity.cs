using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class ChangeVelocity : MonoBehaviour
{
    WebSocket ws;

    [SerializeField] private float oringGravityScale = default;

    private GameObject ball = null;

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

    private void VelocityChange()
    {
        StartCoroutine(Co_ChageVelocity());
    }

    private IEnumerator Co_ChageVelocity()
    {
        if(ball != null)
        {
            float _ChangeGravityScale = Random.Range(-30, 30);
            ball.GetComponent<Rigidbody2D>().gravityScale = oringGravityScale + _ChangeGravityScale;
            yield return new WaitForSeconds(10f);
            ball.GetComponent<Rigidbody2D>().gravityScale = oringGravityScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            VelocityChange();
            ws.Send("type: item," + "item: " + gameObject.name + "," + "x: " + transform.position.x + "," + "y: " + transform.position.y);
            Destroy(gameObject);
            GameManager.Instance.isOnItem = false;
        }
    }
}
