using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingBulletCreate : MonoBehaviour
{
    [SerializeField] GameObject prefabs;
    [SerializeField, Header("������")] int bulletNum;
    [SerializeField, Header("�N�[���^�C��")] float coolTime;
    [SerializeField, Header("�e��")] float speed;
    [SerializeField, Header("�ǔ�����")] float trackingTime;

    TrackingBullet trackingBullet;

    void Awake()
    {
        trackingBullet = prefabs.GetComponent<TrackingBullet>();
        trackingBullet.speed = speed;
        trackingBullet.trackingTime = trackingTime;

        StartCoroutine(Create());
    }

    void Update()
    {
        
    }

    IEnumerator Create()
    {
        for (int i = 0; i < bulletNum; i++)
        {
            Instantiate(prefabs, this.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(coolTime);
        }
    }
}
