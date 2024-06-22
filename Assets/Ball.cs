using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private new CircleCollider2D collider = null;
    private float ballBounciness = default;

    private void Awake()
    {
        collider = GetComponent<CircleCollider2D>();
        ballBounciness = collider.bounciness;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("DeadZone"))
        {
            Destroy(gameObject);
            GameManager.Instance.isOnBall = false;
        }
    }
}
