using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBall : MonoBehaviour
{
    private GameObject ball = null;


    private void Update()
    {
        ball = GameObject.FindWithTag("Ball2");
    }


    //주요기능을 실행하는 함수
    private void LoackBall()
    {
        StartCoroutine(Co_Stop());
    }

    //아이템의 주요 기능을 실행
    private IEnumerator Co_Stop()
    {
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        yield return new WaitForSeconds(0.1f);
    }

    //충돌이벤트
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            LoackBall();
            Destroy(gameObject);
            GameManager.Instance.isOnItem = false;
        }
    }
}
