using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBall_p2 : MonoBehaviour
{
    private GameObject ball = null;


    private void Update()
    {
        ball = GameObject.FindWithTag("Ball");
    }


    //�ֿ����� �����ϴ� �Լ�
    private void LoackBall()
    {
        StartCoroutine(Co_Stop());
    }

    //�������� �ֿ� ����� ����
    private IEnumerator Co_Stop()
    {
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        yield return new WaitForSeconds(0.1f);
    }

    //�浹�̺�Ʈ
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball2")
        {
            LoackBall();
            Destroy(gameObject);
            GameManager1.Instance.isOnItem = false;
        }
    }
}
