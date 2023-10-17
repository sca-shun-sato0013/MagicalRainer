using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BendBullet : MonoBehaviour
{
    float time;
    Vector3 startPos;
    Vector3 relayPos;
    Vector3 targetPos;

    [HideInInspector] public Vector2 relayAjust;
    [HideInInspector] public Vector2 targetAjust;

    [Header("���˕���")] public float angle;
    [HideInInspector] public float speed;

    void Start()
    {
        startPos = this.transform.position;
        relayPos = Quaternion.Euler(0, 0, angle) * new Vector3(startPos.x + relayAjust.x, startPos.y + relayAjust.y, 0);
        targetPos = Quaternion.Euler(0, 0, angle) * new Vector3(startPos.x + targetAjust.x, startPos.y + targetAjust.y);
    }

    void Update()
    {
        //�e�̐i�s��iLerp�̑�O�����ɓ����j
        time += Time.deltaTime;
        //�񎟃x�W�F�Ȑ����g��
        //�X�^�[�g���璆�p�n�_���Ȃ��x�N�g����𑖂�_�̈ʒu
        var firstVec = Vector3.Lerp(startPos, relayPos, time / speed);
        //���p�n�_����^�[�Q�b�g�܂ł��Ȃ��x�N�g����𑖂�_�̈ʒu
        var SecondVec = Vector3.Lerp(relayPos, targetPos, time / speed);
        //��̓�_���Ȃ��x�N�g����𑖂�_�i�e�j�̈ʒu
        var vec = Vector3.Lerp(firstVec, SecondVec, time / speed);
        //�e�̈ʒu��������
        this.transform.position = vec;
    }
}
