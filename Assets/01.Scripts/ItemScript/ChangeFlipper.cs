using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFlipper : MonoBehaviour
{
    [SerializeField] private float oringScale = default;
    [SerializeField] private float minScale = default;
    [SerializeField] private float maxScale = default;
    [SerializeField] private float itmeDurationTime = default;

    private bool isChange = false;

    public GameObject leftPin = null;
    public GameObject rightPin = null;

    public float xpos;
    public float ypos;
    public Vector2 newposition;
    public SetBlind AppearBlind;

    private void Start()
    {
        PosSet();
    }

    private void Update()
    {
        leftPin = GameObject.FindWithTag("LeftPin");
        rightPin = GameObject.FindWithTag("RightPin");
    }

    private void SetFlipperEvent()
    {
        float choseEvent = Random.Range(0, 2);

        if(isChange == false)
        {
            switch (choseEvent)
            {
                case 0:
                    {
                        SetSamllFlipper();
                        break;
                    }
                case 1:
                    {
                        SetSamllFlipper();
                        break;
                    }
            }
        }
    }

    private void SetSamllFlipper()
    {
        StartCoroutine(Co_SetSamllFlipper());
    }

    private void SetLargeFlipper()
    {
        StartCoroutine(Co_SetLargeFlipper());
    }

    private void SetFlipperSize(float size)
    {
        isChange = true;
        leftPin.transform.localScale = new Vector3(-size, 1f, 1f);
        rightPin.transform.localScale = new Vector3(size, 1f, 1f);
    }

    private void SetFlipperOriginSize(float size)
    {
        isChange = false;
        leftPin.transform.localScale = new Vector3(-size, 1f, 1f);
        rightPin.transform.localScale = new Vector3(size, 1f, 1f);
    }

    private IEnumerator Co_SetSamllFlipper()
    {
        SetFlipperSize(minScale);
        yield return new WaitForSeconds(itmeDurationTime);
        SetFlipperSize(oringScale);

    }

    private IEnumerator Co_SetLargeFlipper()
    {
        SetFlipperSize(maxScale);
        yield return new WaitForSeconds(itmeDurationTime);
        SetFlipperSize(oringScale);
    }

    void PosSet()
    {
        xpos = Random.Range(-160, 160);
        ypos = Random.Range(-200, 270);
        newposition = new Vector2(xpos, ypos);
        transform.position = newposition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            SetFlipperEvent();
            PosSet();
        }
        else if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Obstacle")
        {
            PosSet();
            Debug.Log("¥Í¿Ω");
        }
    }
}
