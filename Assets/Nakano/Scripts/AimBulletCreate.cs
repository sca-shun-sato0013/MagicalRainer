using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���@�Ɍ������Ĕ��˂����e�𐶐�
/// </summary>
public class AimBulletCreate : MonoBehaviour
{
    [SerializeField, Header("AimBullet")] GameObject prefabs;
    [SerializeField, Header("������")] int bulletNum;
    [SerializeField, Header("�N�[���^�C��")] float coolTime;
    [SerializeField, Header("�e��")] float speed;

    AimBullet aimBullet;

    public bool isCreate = false;
    bool tmp = false;
    int count = 0;

    Canvas canvas;
    RectTransform rt;
    Vector3 pos;
    TransformChange tc = new();

    void Awake()
    {
        aimBullet = prefabs.GetComponent<AimBullet>();
        aimBullet.speed = speed;

        canvas = GameObject.FindWithTag("Canvas").GetComponent<Canvas>();
        rt = GetComponent<RectTransform>();
    }

    void Update()
    {
        pos = tc.PositionChange(rt, canvas);

        if (isCreate)
        {
            //isCreate = false;
            count++;
            if(count == 1)
            {
                tmp = true;
            }
        }

        if(tmp)
        {
            tmp = false;
            StartCoroutine(Create());
        }
    }

    IEnumerator Create()
    {
        for (int i = 0; i < bulletNum; i++)
        {
            Instantiate(prefabs, pos, Quaternion.identity);
            yield return new WaitForSeconds(coolTime);
        }
    }
}
