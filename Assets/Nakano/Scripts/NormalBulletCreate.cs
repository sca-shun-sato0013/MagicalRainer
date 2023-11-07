using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBulletCreate : MonoBehaviour
{
    [SerializeField, Header("NormalBullet")] GameObject prefabs;
    [SerializeField, Header("��������")] float createTime;
    //[SerializeField, Header("������")] int bulletNum;
    [SerializeField, Header("�N�[���^�C��")] float coolTime;
    [SerializeField, Header("�e��")] float speed;

    [SerializeField, Header("�p�x"), Tooltip("NormalBullets�Ŏw�肵���p�x���D�悳���")] float angle = 0;
    [SerializeField, Header("������"), Tooltip("�������e�𐶐�����ꍇ�ɕ��������w�� �p�x�͐ݒ肵�Ă����Ӗ��ɂȂ� ���͂�1�ȏ�")] int way = 1;
    [SerializeField, Header("�p�x����"), Tooltip("�������e�̊p�x�𒲐�����")] float adjustmentAngle = 0; 
    float parentAngle;

    GameObject parent;
    NormalBullet normalBullet;

    public bool isCreate = false;

    float t = 0;
    bool isCount = false;

    Canvas canvas;
    RectTransform rt;
    Vector3 pos;
    TransformChange tc = new();

    void Awake()
    {
        parent = transform.parent.gameObject;
        parentAngle = parent.GetComponent<Transform>().localEulerAngles.z;

        //���x�ݒ�
        normalBullet = prefabs.GetComponent<NormalBullet>();
        normalBullet.speed = speed;

        if (way < 1) { way = 1; } //�w�肳�ꂽway��1�����̂Ƃ��A1�ɂ���

        //�������e�̂Ƃ��A�e���m�̊Ԃ̊p�x���Z�o
        if (way > 1) { angle = 360 / way; }
        else { adjustmentAngle = 0; }

        canvas = GameObject.FindWithTag("Canvas").GetComponent<Canvas>();
        rt = GetComponent<RectTransform>();
    }

    void Update()
    {
        pos = tc.PositionChange(rt, canvas);

        if (isCreate)
        {
            isCreate = false;
            isCount = true;
            t = 0;
            StartCoroutine(Create());
        }

        if(isCount)
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
                GameObject obj = Instantiate(prefabs, pos, Quaternion.identity);
                parentAngle = parent.GetComponent<RectTransform>().rotation.z;
                obj.GetComponent<NormalBullet>().angle = angle * j + adjustmentAngle + parentAngle;
            }
            yield return new WaitForSeconds(coolTime);
        }
        isCount = false;
    }
}
