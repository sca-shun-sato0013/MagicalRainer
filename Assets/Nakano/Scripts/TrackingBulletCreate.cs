using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingBulletCreate : MonoBehaviour
{
    Canvas canvas;
    [SerializeField, Header("TrackingBullet")] GameObject prefabs;
    [SerializeField, Header("������")] int bulletNum;
    [SerializeField, Header("�N�[���^�C��")] float coolTime;
    [SerializeField, Header("�e��")] float speed;
    [SerializeField, Header("�ǔ�����")] float trackingTime;

    TrackingBullet trackingBullet;

    public bool isCreate = false;
    bool tmp = false;
    int count = 0;

    RectTransform rt;
    Vector3 pos;

    TransformChange tc;

    void Awake()
    {
        tc = gameObject.AddComponent<TransformChange>();
        canvas = GameObject.FindWithTag("Canvas").GetComponent<Canvas>();

        trackingBullet = prefabs.GetComponent<TrackingBullet>();
        trackingBullet.speed = speed;
        trackingBullet.trackingTime = trackingTime;

        rt = GetComponent<RectTransform>();
    }

    void Update()
    {
        pos = tc.PositionChange(rt, canvas);

        if (!isCreate) { count = 0; }
        if (isCreate)
        {
            isCreate = false;
            count++;
            if(count == 1)
            {
                tmp = true;
            }
        }

        if (tmp)
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
