using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHitCounter : MonoBehaviour
{
    [SerializeField] private GameObject golfBall;
    [SerializeField] private int maxHitCount = 3; // 上限値


    public static int ballHitCount = 0;

    void Awake()
    {
        ballHitCount = 0;
    }
    void Start()
    {
        GetBallHitCount();
    }

    void Update()
    {
        // もし ballHitCount が 0 より大きい場合、デバッグログに表示
        if (ballHitCount >= maxHitCount)
        {
            Debug.Log("上限に達しました");
            StopGolfBall();
        }
    }

    private void StopGolfBall()
    {
        Rigidbody rb = golfBall.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero; // ボールの速度をゼロにする
        rb.angularVelocity = Vector3.zero; // ボールの回転速度をゼロにする

    }

    public int GetBallHitCount()
    {
        Debug.Log("Ball Hit Count: " + ballHitCount);
        return ballHitCount;
    }
}
