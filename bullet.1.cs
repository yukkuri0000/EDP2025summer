using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float angle; // �p�x
    [SerializeField] float speed; // ���x
    Vector3 velocity; // �ړ���
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // �v���C���[�ɓ�����������
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.OnHit();
            }

            Destroy(gameObject); // �e������
        }
    }

    void Start()
    {
            // X�����̈ړ��ʂ�ݒ肷��
            velocity.x = speed * Mathf.Cos(angle * Mathf.Deg2Rad);

            // Y�����̈ړ��ʂ�ݒ肷��
            velocity.y = speed * Mathf.Sin(angle * Mathf.Deg2Rad);

            // �e�̌�����ݒ肷��
            float zAngle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg - 90.0f;
            transform.rotation = Quaternion.Euler(0, 0, zAngle);

            // 5�b��ɍ폜
            Destroy(gameObject, 5.0f);


    }
    void Update()
    {
            // ���t���[���A�e���ړ�������
            transform.position += velocity * Time.deltaTime;
    }
    

    public void Init(float input_angle, float input_speed)
    {
        angle = input_angle;
        speed = input_speed;
    }
}