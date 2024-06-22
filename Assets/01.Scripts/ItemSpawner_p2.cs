using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using WebSocketSharp;

public class ItemSpawner_p2 : MonoBehaviour
{
    //WebSocket ws;

    public GameObject[] itemArray = null;
    public Transform[] itemSpawnPosArray = null;

    //private void Start()
    //{
    //    ws = new WebSocket("ws://0.tcp.jp.ngrok.io:10138");
    //    //서버에서 설정한 포트를 넣어줍니다.

    //    ws.OnMessage += (sender, e) =>
    //    {
    //        Debug.Log("Message from server: " + e.Data);
    //    };

    //    ws.OnError += (sender, e) =>
    //    {
    //        Debug.LogError("Error: " + e.Message);
    //    };

    //    ws.Connect();

    //    ws.OnMessage += Call;
    //}

    //void Call(object sender, MessageEventArgs e)
    //{
    //    Debug.Log("주소 :  " + ((WebSocket)sender).Url + ", 데이터 : " + e.Data);
    //}

    private void Update()
    {
        if (GameManager.Instance.isOnItem_p2 == false)
        {
            int itemInxdex = Random.Range(0, itemArray.Length);
            int itemSpawnPosIndex = Random.Range(0, itemSpawnPosArray.Length);

            Instantiate(itemArray[itemInxdex].gameObject, itemSpawnPosArray[itemSpawnPosIndex].position, Quaternion.identity);

            Debug.Log(itemInxdex + " " + itemSpawnPosIndex);

            //ws.Send("type: item," + "item: " + itemArray[itemInxdex].gameObject + "," + "x: " + itemSpawnPosArray[itemSpawnPosIndex].position.x + "," + "y: " + itemSpawnPosArray[itemSpawnPosIndex].position.y);
            
            GameManager.Instance.isOnItem_p2 = true;
        }
    }

}
