using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float angle; // 角度
    [SerializeField] float speed; // 速度
    Vector3 velocity; // 移動量
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // プレイヤーに当たった処理
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.OnHit();
            }

            Destroy(gameObject); // 弾を消す
        }
    }

    void Start()
    {
            // X方向の移動量を設定する
            velocity.x = speed * Mathf.Cos(angle * Mathf.Deg2Rad);

            // Y方向の移動量を設定する
            velocity.y = speed * Mathf.Sin(angle * Mathf.Deg2Rad);

            // 弾の向きを設定する
            float zAngle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg - 90.0f;
            transform.rotation = Quaternion.Euler(0, 0, zAngle);

            // 5秒後に削除
            Destroy(gameObject, 5.0f);


    }
    void Update()
    {
            // 毎フレーム、弾を移動させる
            transform.position += velocity * Time.deltaTime;
    }
    

    public void Init(float input_angle, float input_speed)
    {
        angle = input_angle;
        speed = input_speed;
    }
}