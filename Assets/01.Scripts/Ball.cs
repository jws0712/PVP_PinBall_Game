using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float oringBounciness = default;
    [SerializeField] private float bouncinessDamage = default;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Obstacle")
        {
            AudioManager.instance.PlaySFX("Bound");
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("DeadZone"))
        {
            if (GameManager.Instance.isOnBall == true)
            {
                UIManager.Instance.p2.text = (UIManager.Instance.score_p2 += 1).ToString();
            }
            

            Destroy(gameObject);
            GameManager.Instance.isOnBall = false;
        }
    }
}
