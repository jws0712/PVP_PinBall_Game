using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    private int rotateSpeed;
    void Start()
    {
        rotateSpeed = 100;
    }

    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed);
    }
}
