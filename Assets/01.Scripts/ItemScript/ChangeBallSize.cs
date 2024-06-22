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
    private void SetBallSize()
    {
        StartCoroutine(Co_ChangeBallSize());
    }

    //�������� �ֿ� ����� ����
    private IEnumerator Co_ChangeBallSize()
    {
        ball.transform.localScale = new Vector3(changeSacle, changeSacle, changeSacle);
        yield return new WaitForSeconds(10f);
        ball.transform.localScale = new Vector3(oringScale, oringScale, oringScale);
    }

    //�浹�̺�Ʈ
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
