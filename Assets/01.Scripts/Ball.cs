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

    private void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        mat.bounciness -= bouncinessDamage;
        collider.sharedMaterial = mat;

        Debug.Log(collider.sharedMaterial.bounciness);

        if (collision.gameObject.layer == LayerMask.NameToLayer("DeadZone"))
        {
            Destroy(gameObject);
            GameManager.Instance.isOnBall = false;
        }
    }
}
