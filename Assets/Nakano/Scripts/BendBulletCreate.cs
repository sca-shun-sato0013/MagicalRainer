using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BendBulletCreate : MonoBehaviour
{
    [SerializeField, Header("BendBullet")] GameObject prefabs;
    [SerializeField, Header("��������")] float createTime;
    //[SerializeField, Header("������")] int bulletNum;
    [SerializeField, Header("�N�[���^�C��")] float coolTime;
    [SerializeField, Header("�e���@�y���Ӂz���ƈقȂ�l�������قǒᑬ��")] float speed;

    [SerializeField, Header("�p�x"), Tooltip("BendBullets�Ŏw�肵���p�x���D�悳���")] float angle = 0;
    [SerializeField, Header("������"), Tooltip("�������e�𐶐�����ꍇ�ɕ��������w�� �p�x�͐ݒ肵�Ă����Ӗ��ɂȂ� ���͂�1�ȏ�")] int way = 1;
    [SerializeField, Header("�p�x����"), Tooltip("�������e�̊p�x�𒲐�����")] float adjustmentAngle = 0;

    [SerializeField, Header("�p�x����"), Tooltip("�x�W�F�Ȑ��̍����𒲐�")] Vector2 relayAjust;
    [SerializeField, Header("���B�n�_����"), Tooltip("�x�W�F�Ȑ��̍ŏI�ʒu�𒲐�")] Vector2 targetAjust;

    BendBullet bendBullet;

    public bool isCreate = false;
    [Header("�t��]�ɂ��邩�ǂ���")] public bool isReverse = false;

    float t = 0;
    bool isCount = false;

    private void Awake()
    {
        bendBullet = prefabs.GetComponent<BendBullet>();
        bendBullet.speed = speed;

        if (!isReverse)
        {
            bendBullet.relayAjust = relayAjust;
            bendBullet.targetAjust = targetAjust;
        }
        if(isReverse)
        {
            bendBullet.relayAjust = new Vector2(relayAjust.x * -1, relayAjust.y);
            bendBullet.targetAjust = new Vector2(targetAjust.x * -1, targetAjust.y);
        }

        if (way < 1) { way = 1; } //�w�肳�ꂽway��1�����̂Ƃ��A1�ɂ���

        //�������e�̂Ƃ��A�e���m�̊Ԃ̊p�x���Z�o
        if (way > 1) { angle = 360 / way; }
        else { adjustmentAngle = 0; }
    }

    void Update()
    {
        if (isCreate)
        {
            isCreate = false;
            isCount = true;
            t = 0;
            StartCoroutine(Create());
        }

        if (isCount)
        {
            t += Time.deltaTime;
        }
    }

    IEnumerator Create()
    {
        while (t < createTime)
        {
            for (int j = 1; j <= way; j++)
            {
                GameObject obj = Instantiate(prefabs, this.transform.position, Quaternion.identity);
                obj.GetComponent<BendBullet>().angle = angle * j + adjustmentAngle;
            }
            yield return new WaitForSeconds(coolTime);
        }
        isCount = false;
    }
}
