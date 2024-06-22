using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float oringBounciness = default;
    [SerializeField] private float bouncinessDamage = default;

    private new Collider2D collider = null;
    private PhysicsMaterial2D mat = default;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        mat = collider.sharedMaterial;
        mat.bounciness = oringBounciness;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            AudioManager.instance.PlaySFX("Bound");
        }

        mat.bounciness -= bouncinessDamage;
        collider.sharedMaterial = mat;

        if (collision.gameObject.layer == LayerMask.NameToLayer("DeadZone"))
        {
            Destroy(gameObject);
            GameManager.Instance.isOnBall = false;
        }
    }
}
