using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public float score_p1 = 0;
    public float score_p2 = 0;

    private void Awake()
    {
        Instance = this;
    }

    public Text p1, p2;
}
