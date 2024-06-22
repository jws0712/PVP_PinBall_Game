using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBallSize : MonoBehaviour
{
    [SerializeField] private float oringScale = default;
    [SerializeField] private float changeSacle = default;

    private GameObject ball = null;

    private void Update()
    {
        ball = GameObject.FindWithTag("Ball");
    }

    //주요기능을 실행하는 함수
    private void SetBallSize()
    {
        StartCoroutine(Co_ChangeBallSize());
    }

    //아이템의 주요 기능을 실행
    private IEnumerator Co_ChangeBallSize()
    {
        ball.transform.localScale = new Vector3(changeSacle, changeSacle, changeSacle);
        yield return new WaitForSeconds(10f);
        ball.transform.localScale = new Vector3(oringScale, oringScale, oringScale);
    }

    //충돌이벤트
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            SetBallSize();
            Destroy(gameObject);
            GameManager.Instance.isOnItem = false;
        }
    }
}
