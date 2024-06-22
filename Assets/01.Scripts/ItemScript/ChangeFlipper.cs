using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFlipper : MonoBehaviour
{
    [SerializeField] private float oringScale = default;
    [SerializeField] private float minScale = default;
    [SerializeField] private float maxScale = default;
    [SerializeField] private float itmeDurationTime = default;

    public GameObject leftPin = null;
    public GameObject rightPin = null;

    private void Start()
    {

    }

    private void Update()
    {
        leftPin = GameObject.FindWithTag("LeftPin");
        rightPin = GameObject.FindWithTag("RightPin");

        SetLargeFlipper();
    }

    private void SetSamllFlipper()
    {
        leftPin.transform.localScale = new Vector3(-minScale, 1f, 1f);
        rightPin.transform.localScale = new Vector3(minScale, 1f, 1f);
    }

    private void SetLargeFlipper()
    {
        leftPin.transform.localScale = new Vector3(-maxScale, 1f, 1f);
        rightPin.transform.localScale = new Vector3(maxScale, 1f, 1f);
    }

    //private IEnumerator Co_SetSamllFlipper()
    //{

    //}

    //private IEnumerator Co_SetLargeFlipper()
    //{

    //}
}
