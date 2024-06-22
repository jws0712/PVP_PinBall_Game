using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindObject_p2 : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(Co_Destroy());
    }

    private IEnumerator Co_Destroy()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
