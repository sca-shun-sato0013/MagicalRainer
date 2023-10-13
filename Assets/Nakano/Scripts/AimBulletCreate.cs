using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���@�Ɍ������Ĕ��˂����e�𐶐�
/// </summary>
public class AimBulletCreate : MonoBehaviour
{
    [SerializeField] GameObject prefabs;
    [SerializeField, Header("������")] int bulletNum;
    [SerializeField, Header("�N�[���^�C��")] float coolTime;
    [SerializeField, Header("�e��")] float speed;

    AimBullet aimBullet;

    void Awake()
    {
        aimBullet = prefabs.GetComponent<AimBullet>();
        aimBullet.speed = speed;

        StartCoroutine(Create());
    }

    void Update()
    {
    }

    IEnumerator Create()
    {
        for (int i = 0; i < bulletNum; i++)
        {
            Instantiate(prefabs, this.transform.position, Quaternion.identity, gameObject.transform);
            yield return new WaitForSeconds(coolTime);
        }
    }
}
