using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFlipper : MonoBehaviour
{
    [SerializeField] private float oringScale = default;
    [SerializeField] private float minScale = default;
    [SerializeField] private float maxScale = default;
    [SerializeField] private float itmeDurationTime = default;

    private Vector3 oringLeftPinScale = Vector3.zero;
    private Vector3 oringRightPinScale = Vector3.zero;

    private void Start()
    {
        oringLeftPinScale = GameObject.FindWithTag("LeftPin").transform.localScale;
        oringRightPinScale = GameObject.FindWithTag("RightPin").transform.localScale;
    }

    private void SetSamllFlipper()
    {
        
    }

    private void SetLargeFlipper()
    {

    }

    //private IEnumerator Co_SetSamllFlipper()
    //{

    //}

    //private IEnumerator Co_SetLargeFlipper()
    //{

    //}
}
