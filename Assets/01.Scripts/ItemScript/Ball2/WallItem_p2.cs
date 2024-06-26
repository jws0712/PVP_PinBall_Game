using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class WallItem_p2 : MonoBehaviour
{

    [SerializeField] private GameObject wall = null;

   

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball2")
        {
            Instantiate(wall, transform.position, Quaternion.identity);
            GameManager1.Instance.isOnItem = false;
            Destroy(gameObject);
        }
    }
}
