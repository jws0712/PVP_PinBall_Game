using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    public int Speed;
    void Start()
    {
        Speed = 100;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, Speed);
    }
}
