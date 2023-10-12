using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player��_���Ĕ��ˁ@�ǔ��͂��Ȃ�
/// </summary>
public class AimBullet : MonoBehaviour
{
    GameObject player;
    Vector3 playerPos;
    Vector3 bulletPos;

    Vector3 direction;

    [SerializeField, Header("�e��")] float speed;

    void Start()
    {
        //�������Ɏ��g�̈ʒu�ƃv���C���[�̈ʒu���擾����
        player = GameObject.FindWithTag("Player");
        playerPos = player.transform.position;
        bulletPos = this.transform.position;

        direction = (playerPos - bulletPos).normalized;

        Quaternion quaternion = Quaternion.LookRotation(direction);
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
