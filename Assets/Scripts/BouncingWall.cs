using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingWall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GolfBall"))
        {
            Debug.Log("GolfBall has hit the wall!");
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // 現在の速度の大きさを取得
                //float currentSpeed = rb.velocity.magnitude;

                // 反射方向を計算
                Vector3 reflectDir = Vector3.Reflect(collision.relativeVelocity.normalized, collision.contacts[0].normal);

                // 新しい速度を設定（例：1.5倍の速さ）
                //rb.velocity = reflectDir * currentSpeed * 20f;

                rb.AddForce(reflectDir * 35f, ForceMode.Impulse);
            }
        }
    }
}
