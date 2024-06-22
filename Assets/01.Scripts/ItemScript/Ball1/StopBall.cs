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
        if (collision.gameObject.tag == "Ball")
        {
            LoackBall();
            Destroy(gameObject);
            GameManager.Instance.isOnItem = false;
        }
    }
}
