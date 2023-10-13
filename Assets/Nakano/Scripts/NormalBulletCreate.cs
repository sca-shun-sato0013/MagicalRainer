using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBulletCreate : MonoBehaviour
{
    [SerializeField] GameObject prefabs;
    [SerializeField, Header("������")] int bulletNum;
    [SerializeField, Header("�N�[���^�C��")] float coolTime;
    [SerializeField, Header("�e��")] float speed;

    [SerializeField, Header("�p�x"), Tooltip("NormalBullets�Ŏw�肵���p�x���D�悳���")] float angle = 0;
    [SerializeField, Header("������"), Tooltip("�������e�𐶐�����ꍇ�ɕ��������w�� �p�x�͐ݒ肵�Ă����Ӗ��ɂȂ� ���͂�1�ȏ�")] int way = 1;
    [SerializeField, Header("�p�x����"), Tooltip("�������e�̊p�x�𒲐�����")] float adjustmentAngle = 0; 

    NormalBullet normalBullet;

    void Awake()
    {
        //���x�ݒ�
        normalBullet = prefabs.GetComponent<NormalBullet>();
        normalBullet.speed = speed;

        if (way < 1) { way = 1; } //�w�肳�ꂽway��1�����̂Ƃ��A1�ɂ���

        //�������e�̂Ƃ��A�e���m�̊Ԃ̊p�x���Z�o
        if (way > 1) { angle = 360 / way; }
        else { adjustmentAngle = 0; }

        StartCoroutine(Create());
    }

    void Update()
    {
        
    }

    IEnumerator Create()
    {
        for (int i = 0; i < bulletNum; i++)
        {
            for (int j = 1; j <= way; j++)
            {
                GameObject obj = Instantiate(prefabs, this.transform.position, Quaternion.identity, gameObject.transform);
                obj.GetComponent<NormalBullet>().angle = angle * j + adjustmentAngle;
            }
            yield return new WaitForSeconds(coolTime);
        }
    }
}
