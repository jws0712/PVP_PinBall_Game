using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;

    private Animator animator = null;

    private void Awake()
    {
        Instance = this;

        animator = GetComponent<Animator>();
    }

    public void CamreaShake(bool isCollision)
    {
        animator.SetBool("isShake", isCollision);
    }


}
