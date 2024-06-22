using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilpperController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rightFlipper = null;
    [SerializeField] Rigidbody2D leftFlipper = null;

    private void Update()
    {
        leftFlipper.AddTorque(25f);

        if(Input.GetKey(KeyCode.J))
        {
            rightFlipper.AddTorque(-25f);
        }
        else
        {
            rightFlipper.AddTorque(20f);
        }

        if (Input.GetKey(KeyCode.J))
        {
            leftFlipper.AddTorque(25f);
        }
        else
        {
            leftFlipper.AddTorque(-20f);
        }
    }
}
