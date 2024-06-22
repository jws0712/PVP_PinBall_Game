using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilpperController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rightFlipper, leftFlipper = null;
    [SerializeField] private float flipperPower = default;

    private void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            rightFlipper.AddTorque(-(flipperPower));
        }
        else
        {
            rightFlipper.AddTorque(flipperPower);
        }
        if(Input.GetKey(KeyCode.F))
        {
            leftFlipper.AddTorque(flipperPower);
        }
        else
        {
            leftFlipper.AddTorque(-(flipperPower));
        }

        
    }
}
