using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �w�肵�������ɒ����I�ɔ���
/// </summary>
public class NormalBullet : MonoBehaviour
{
    [SerializeField, Header("���˕���"), Tooltip("�p�x0�̂Ƃ��E�ցA�p�x180�̂Ƃ�����\n�p�x�͎O�p�֐��̃C���[�W��")] float angle;
    [SerializeField, Header("�e��")] float speed;
    Vector3 direction;

    void Start()
    {
        //�p�x��P�ʃx�N�g���ɕς���
        direction = AngleToVector3(angle);
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    /// <summary>
    /// �p�x����P�ʃx�N�g�����擾
    /// </summary>
    Vector2 AngleToVector3(float angle)
    {
        var radian = angle * (Mathf.PI / 180);
        return new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0).normalized;
    }
}
