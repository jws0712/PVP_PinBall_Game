using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class FilpperController : MonoBehaviour
{
    WebSocket ws;

    [SerializeField] Rigidbody2D rightFlipper, leftFlipper = null;
    [SerializeField] private float flipperPower = default;

    private bool isConnected = false;

    private bool isLeft = false;
    private bool isRight = false;

    private void Start()
    {
        ws = new WebSocket("ws://0.tcp.jp.ngrok.io:10138");
        //�������� ������ ��Ʈ�� �־��ݴϴ�.

        ws.OnMessage += (sender, e) =>
        {
            Debug.Log("Message from server: " + e.Data);
        };

        ws.OnOpen += (sender, e) =>
        {
            Debug.Log("Connection opened");
            isConnected = true; // Set the flag to true when the connection is open
        };

        ws.OnClose += (sender, e) =>
        {
            Debug.Log("Connection closed");
            isConnected = false; // Set the flag to false when the connection is closed
        };

        ws.OnError += (sender, e) =>
        {
            Debug.LogError("Error: " + e.Message);
        };

        ws.Connect();
        //�����մϴ�.
        ws.OnMessage += Call;
    }

    void Call(object sender, MessageEventArgs e)
    {
        Debug.Log("�ּ� :  " + ((WebSocket)sender).Url + ", ������ : " + e.Data);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            rightFlipper.AddTorque(-(flipperPower));
            ws.Send("type: my_flip, left:"+ isLeft+", right:"+isRight);
            isRight = true;
        }
        else
        {
            rightFlipper.AddTorque(flipperPower);
            isRight = false;
            ws.Send("type: my_flip, left:" + isLeft + ", right:" + isRight);

        }
        if (Input.GetKey(KeyCode.F))
        {
            leftFlipper.AddTorque(flipperPower);
            ws.Send("type: my_flip, left:" + isLeft + ", right:" + isRight);
            isLeft = true;
        }
        else
        {
            leftFlipper.AddTorque(-(flipperPower));
            isLeft = false;
            ws.Send("type: my_flip, left:" + isLeft + ", right:" + isRight);

        }
    }
}
