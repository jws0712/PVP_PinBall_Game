using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVelocity_p2 : MonoBehaviour
{

    [SerializeField] private float oringGravityScale = default;

    private GameObject ball = null;


    private void Update()
    {
        ball = GameObject.FindWithTag("Ball");
    }

    private void VelocityChange()
    {
        StartCoroutine(Co_ChageVelocity());
    }

    private IEnumerator Co_ChageVelocity()
    {
        if(ball != null)
        {
            float _ChangeGravityScale = Random.Range(-30, 30);
            ball.GetComponent<Rigidbody2D>().gravityScale = oringGravityScale + _ChangeGravityScale;
            yield return new WaitForSeconds(10f);
            ball.GetComponent<Rigidbody2D>().gravityScale = oringGravityScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball2")
        {
            VelocityChange();
            Destroy(gameObject);
            GameManager1.Instance.isOnItem = false;
        }
    }
}
