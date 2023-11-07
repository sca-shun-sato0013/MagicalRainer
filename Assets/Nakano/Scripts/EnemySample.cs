using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �e�������݂̓G�����̗�ł�
/// </summary>
public class EnemySample : MonoBehaviour
{
    //�����������e�ɉ�����Nakano > Prefabs > BulletsCreate�t�H���_���̓K����Prefab��G�I�u�W�F�N�g�̎q�I�u�W�F�N�g�Ƃ��Ēǉ����Ă�������

    //�q�I�u�W�F�N�g���w�肷�� �ϐ����͂����R�Ɂ@SerializeField�Ŏw�肷��񂶂�Ȃ���GetChild���\�b�h�Ƃ��Ŏq�I�u�W�F�N�g���擾����ł��ǂ��ł�
    [SerializeField] GameObject bulletsCreate;

    //�擾����Script�̐錾�@�t����Prefab�Ɠ����̂�����ŗǂ��ł��@�ǂ��t���邩�͎d�l�����Q�Ƃ��Ă�������
    AimBulletCreate aim; �@�@�@�@�@//�u���@�Ɍ������āv�ƂȂ��Ă���ꍇ�@�X�e�[�W1/�m�[�}��/�t�F�[�Y1�@�Ȃǁ@�v���n�u��BigAimBulletCreate(�������̒e ��)��t����Ƃ��������
    NormalBulletCreate normal;�@�@ //�u���@�͑_�킸�ǔ������Ȃ��v�ꍇ�@�@�X�e�[�W2/�m�[�}��/�t�F�[�Y4�@�Ȃǁ@�v���n�u��BigNormalBulletCreate(�������̒e ��)��t����Ƃ��������
    TrackingBulletCreate tracking; //�u�ǔ�����v�ꍇ�@�@�@�@�@�@�@�@�@�@�X�e�[�W2/�n�[�h/�t�F�[�Y1�@�Ȃ�
    LinerBulletCreate liner; �@�@�@//����ɔ��˂���ꍇ�@�@�@�@�@�@�@�@�@�X�e�[�W2/�n�[�h/�t�F�[�Y1/����2��

    //��񂾂��������邽�߂̃t���O�@������ւ�͏�肢���Ƃ���Ă�������
    bool isTmp = true;

    void Start()
    {
        //�錾����Script��GetComponent��bulletsCreate����擾
        //aim = bulletsCreate.GetComponent<AimBulletCreate>();
        //normal = bulletsCreate.GetComponent<NormalBulletCreate>();
        //tracking = bulletsCreate.GetComponent<TrackingBulletCreate>();
        liner = bulletsCreate.GetComponent<LinerBulletCreate>();

        //isCreate������
        //aim.isCreate = false;
        //normal.isCreate = false;
        //tracking.isCreate = false;
        liner.isCreate = false;

        isTmp = true;
    }

    void Update()
    {
        //this.transform.Rotate(0f, 0f, 1.0f);

        //�ړ�
        //this.transform.Translate(Vector3.right * 5 * Time.deltaTime);
        
        //��Ƃ��ē���̈ʒu�܂ōs������e�𐶐�
        if(isTmp)
        {
            //aim.isCreate = true; //�e�𐶐�����Script��isCreate��true�Ɂ@isCreate��true�̂Ƃ��ɐݒ肵���e���𐶐����܂�
            //normal.isCreate = true;
            //tracking.isCreate = true;
            liner.isCreate = true;
            isTmp = false;
        }
    }
}
