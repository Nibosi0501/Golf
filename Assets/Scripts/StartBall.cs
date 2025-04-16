using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBall : MonoBehaviour
{
    [SerializeField] GameObject golfBall;
    [SerializeField] float initialSpeed = 10f;
    [SerializeField] Vector3 startDirection = Vector3.forward;
    private Rigidbody rb;


    void Start()
    {
        StartCoroutine(WaitUntilPositionReached(-5.0f));

        rb = golfBall.GetComponent<Rigidbody>();

        // 初速×方向に一度だけ力を加える
        rb.AddForce(startDirection.normalized * initialSpeed, ForceMode.Impulse);
    }

    private IEnumerator WaitUntilPositionReached(float targetZ)
    {
        while (transform.position.z < targetZ)
        {
            yield return null; // 次のフレームまで待機
        }

        CameraFollow cameraFollow = FindObjectOfType<CameraFollow>();
        if (cameraFollow != null)
        {
            cameraFollow.SetFollowTarget(); // カメラのターゲットをこのオブジェクトに設定
        }

        yield break; // コルーチンを終了
    }
}
