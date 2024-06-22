using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class WallItem : MonoBehaviour
{
    [SerializeField] private GameObject wall = null;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Instantiate(wall, transform.position, Quaternion.identity);
            GameManager.Instance.isOnItem = false;
            Destroy(gameObject);
        }
    }
}
