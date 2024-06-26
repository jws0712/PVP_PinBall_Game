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

    

    private void Update()
    {
        if (GameManager1.Instance.isOnItem == false)
        {
            int itemInxdex = Random.Range(0, itemArray.Length);
            int itemSpawnPosIndex = Random.Range(0, itemSpawnPosArray.Length);

            Instantiate(itemArray[itemInxdex].gameObject, itemSpawnPosArray[itemSpawnPosIndex].position, Quaternion.identity);

            Debug.Log(itemInxdex + " " + itemSpawnPosIndex);

            //ws.Send("type: item," + "item: " + itemArray[itemInxdex].gameObject + "," + "x: " + itemSpawnPosArray[itemSpawnPosIndex].position.x + "," + "y: " + itemSpawnPosArray[itemSpawnPosIndex].position.y);
            
            GameManager1.Instance.isOnItem = true;
        }
    }

}
