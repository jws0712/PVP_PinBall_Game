using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class ChangeFlipperSize : MonoBehaviour
{
    WebSocket ws;

    [SerializeField] private float oringScale = default;
    [SerializeField] private float minScale = default;
    [SerializeField] private float maxScale = default;
    [SerializeField] private float itmeDurationTime = default;

    private bool isChange = false;

    public GameObject leftPin = null;
    public GameObject rightPin = null;

    public float xpos;
    public float ypos;
    public Vector2 newposition;

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
        leftPin = GameObject.FindWithTag("LeftPin");
        rightPin = GameObject.FindWithTag("RightPin");
    }

    private void SetFlipperEvent()
    {
        float choseEvent = Random.Range(0, 2);

        if(isChange == false)
        {
            switch (choseEvent)
            {
                case 0:
                    {
                        SetSamllFlipper();
                        break;
                    }
                case 1:
                    {
                        SetSamllFlipper();
                        break;
                    }
            }
        }
    }

    private void SetSamllFlipper()
    {
        StartCoroutine(Co_SetSamllFlipper());
    }

    private void SetLargeFlipper()
    {
        StartCoroutine(Co_SetLargeFlipper());
    }

    private void SetFlipperSize(float size)
    {
        isChange = true;
        leftPin.transform.localScale = new Vector3(-size, 1f, 1f);
        rightPin.transform.localScale = new Vector3(size, 1f, 1f);
    }

    private void SetFlipperOriginSize(float size)
    {
        isChange = false;
        leftPin.transform.localScale = new Vector3(-size, 1f, 1f);
        rightPin.transform.localScale = new Vector3(size, 1f, 1f);
    }

    private IEnumerator Co_SetSamllFlipper()
    {
        SetFlipperSize(minScale);
        yield return new WaitForSeconds(itmeDurationTime);
        SetFlipperSize(oringScale);

    }

    private IEnumerator Co_SetLargeFlipper()
    {
        SetFlipperSize(maxScale);
        yield return new WaitForSeconds(itmeDurationTime);
        SetFlipperSize(oringScale);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            SetFlipperEvent();
            ws.Send("type: item," + "item: " + gameObject.name + "," + "x: " + transform.position.x + "," + "y: " + transform.position.y);
            Destroy(gameObject);
            GameManager.Instance.isOnItem = false;
        }
    }
}
