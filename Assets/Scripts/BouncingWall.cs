using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingWall : MonoBehaviour
{
    [SerializeField] private float bounceForce = 20f; // 反発力の強さ
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GolfBall"))
        {
            Debug.Log("GolfBall has hit the wall!");
            // ボールが壁に当たった回数をカウント
            BallHitCounter.ballHitCount++;

            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // 反射方向を計算
                Vector3 reflectDir = GetBounceDirection(collision.relativeVelocity.normalized, collision.contacts[0].normal);


                rb.AddForce(reflectDir * bounceForce, ForceMode.Impulse);
            }
        }
    }

    private Vector3 GetBounceDirection(Vector3 incomingDirection, Vector3 normal)
    {
        // 入射ベクトルを法線ベクトルに対して反射させる
        Vector3 reflectDir = Vector3.Reflect(incomingDirection, normal);

        // 反射ベクトルのY成分を0にする
        // これにより、Y成分が無視され、X-Z平面上の反射ベクトルが得られる
        reflectDir.y = 0;

        // 反射ベクトルを返す
        return reflectDir;
    }
}
