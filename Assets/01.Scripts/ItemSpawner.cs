using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itemArray = null;
    public Transform[] itemSpawnPosArray = null;

    private void Update()
    {
        if (GameManager.Instance.isOnItem == false)
        {
            int itemInxdex = Random.Range(0, itemArray.Length);
            int itemSpawnPosIndex = Random.Range(0, itemSpawnPosArray.Length);

            Instantiate(itemArray[itemInxdex].gameObject, itemSpawnPosArray[itemSpawnPosIndex].position, Quaternion.identity);
            GameManager.Instance.isOnItem = true;
        }
    }

}
