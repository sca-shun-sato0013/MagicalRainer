using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���@�Ɍ������Ĕ��˂����e�𐶐�
/// </summary>
public class AimBulletCreate : MonoBehaviour
{
    [SerializeField] GameObject prefabs;
    [SerializeField, Header("�e�̉摜")] Sprite sprite;
    [SerializeField, Header("������")] int bulletNum;
    [SerializeField, Header("�N�[���^�C��")] float coolTime;
    [SerializeField, Header("�e��")] float speed;

    AimBullet aimBullet;

    public bool isCreate = false;

    void Awake()
    {
        aimBullet = prefabs.GetComponent<AimBullet>();
        aimBullet.speed = speed;
        prefabs.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    void Update()
    {
        if(isCreate)
        {
            isCreate = false;
            StartCoroutine(Create());
        }
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
