using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class FilpperController : MonoBehaviour
{
    WebSocket ws;

    [SerializeField] Rigidbody2D rightFlipper, leftFlipper, p2_rightFlipper, p2_leftFlipper = null;
    [SerializeField] private float flipperPower = default;

    [SerializeField] private bool isP2 = false;

    private bool isConnected = false;

    private bool isLeft = false;
    private bool isRight = false;

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
        if (Input.GetKey(KeyCode.J))
        {
            rightFlipper.AddTorque(-(flipperPower));
            //ws.Send("type: my_flip, left:"+ isLeft+", right:"+isRight);
            isRight = true;
        }
        else
        {
            rightFlipper.AddTorque(flipperPower);
            isRight = false;
            //ws.Send("type: my_flip, left:" + isLeft + ", right:" + isRight);

        }
        if (Input.GetKey(KeyCode.F))
        {
            leftFlipper.AddTorque(flipperPower);
           // ws.Send("type: my_flip, left:" + isLeft + ", right:" + isRight);
            isLeft = true;
        }
        else
        {
            leftFlipper.AddTorque(-(flipperPower));
            isLeft = false;
            //ws.Send("type: my_flip, left:" + isLeft + ", right:" + isRight);

        }

        if(isP2 == true)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                p2_rightFlipper.AddTorque(-(flipperPower));
            }
            else
            {
                p2_rightFlipper.AddTorque(flipperPower);

            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                p2_leftFlipper.AddTorque(flipperPower);
            }
            else
            {
                p2_leftFlipper.AddTorque(-(flipperPower));

            }
        }
    }
}
