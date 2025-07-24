using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher1 : MonoBehaviour
{
    float timeCount = 0; // �o�ߎ���
    float shotAngle = 0; // ���ˊp�x
    [SerializeField] GameObject shotBullet; // ���˂���e

    void Start()
    {
        // ���������Ȃ�
    }

    void Update()
    {
        // �O�t���[������̎��Ԃ̍������Z
        timeCount += Time.deltaTime;

        // 0.1�b�𒴂��Ă��邩
        if (timeCount > 0.05f)
        {
            timeCount = 0; // �Ĕ��˂̂��߂Ɏ��Ԃ����Z�b�g

            shotAngle += 10;

            // GameObject��V���ɐ�������
            // �������F��������GameObject
            // �������F����������W
            // ��O�����F��������p�x
            // �߂�l�F��������GameObject
            GameObject createObject = Instantiate(shotBullet, transform.position, Quaternion.identity);

            // ��������GameObject�ɐݒ肳��Ă���ABullet�X�N���v�g���擾����
            Bullet bulletScript = createObject.GetComponent<Bullet>();

            // Bullet�X�N���v�g��Init���Ăяo��
            bulletScript.Init(shotAngle, 3);
        }
    }
}