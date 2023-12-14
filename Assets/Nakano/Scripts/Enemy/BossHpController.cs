using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHpController : MonoBehaviour
{
    [SerializeField] BossController bossController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!bossController.Invincible) //���G��ԂłȂ��Ƃ�
        {
            //�v���C���[�̒e�ɓ���������
            if (collision.gameObject.tag == "PlayerBullet")
            {
                //HP�����@�����ʂ͍U���ɉ����ĕω�
                bossController.BossHp -= 100;
            }
        }
    }
}
