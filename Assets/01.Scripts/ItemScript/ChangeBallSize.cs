using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class ChangeBallSize : MonoBehaviour
{
    [SerializeField] private float oringScale = default;
    [SerializeField] private float changeSacle = default;

    WebSocket ws;

    private GameObject ball = null;

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
    private void SetBallSize()
    {
        StartCoroutine(Co_ChangeBallSize());
    }

    //아이템의 주요 기능을 실행
    private IEnumerator Co_ChangeBallSize()
    {
        ball.transform.localScale = new Vector3(changeSacle, changeSacle, changeSacle);
        yield return new WaitForSeconds(10f);
        ball.transform.localScale = new Vector3(oringScale, oringScale, oringScale);
    }

    //충돌이벤트
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            SetBallSize();
            ws.Send("type: item," + "item: " + gameObject.name + "," + "x: " + transform.position.x + "," + "y: " + transform.position.y);
            Destroy(gameObject);
            GameManager.Instance.isOnItem = false;
        }
    }
}
