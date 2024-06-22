using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class BlindItem : MonoBehaviour
{
    [SerializeField] private GameObject apperBlind = null;

    public void BlindSet()
    {
        Instantiate(apperBlind, Vector3.zero, Quaternion.identity);
        transform.position = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            BlindSet();
            Destroy(gameObject);
            GameManager.Instance.isOnItem = false;
        }
    }
}
