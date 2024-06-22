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

    //�ֿ����� �����ϴ� �Լ�
    private void SetBallSize()
    {
        StartCoroutine(Co_ChangeBallSize());
    }

    //�������� �ֿ� ����� ����
    private IEnumerator Co_ChangeBallSize()
    {
        ball.transform.localScale = new Vector3(changeSacle, changeSacle, changeSacle);
        yield return new WaitForSeconds(10f);
        ball.transform.localScale = new Vector3(oringScale, oringScale, oringScale);
    }

    //�浹�̺�Ʈ
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
