using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float spawnDelay = default;
    [SerializeField] private float ballSpawnPower = default;
    [SerializeField] private Transform ballSpawnPoint = null;
    [SerializeField] private GameObject ballPreFab = null;

    public static GameManager Instance;

    [HideInInspector]
    public bool isOnBall = default;


    //ΩÃ±€≈Ê
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        GameObject ballobject = GameObject.FindWithTag("Ball");

        if(ballobject == null && isOnBall == false)
        {
            StartCoroutine(Co_SpawnBall());
            isOnBall = true;
        }
    }

    //∞¯¿Ã DeadZoneø° ¥Íæ“¿ª∂ß
    private IEnumerator Co_SpawnBall()
    {
        yield return new WaitForSeconds(spawnDelay);

        GameObject ball = Instantiate(ballPreFab, ballSpawnPoint.position, Quaternion.identity);

        ball.GetComponent<Rigidbody2D>().AddForce(Vector2.up * ballSpawnPower, ForceMode2D.Impulse);
    }
}
