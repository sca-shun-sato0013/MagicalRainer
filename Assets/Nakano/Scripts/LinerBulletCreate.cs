using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinerBulletCreate : MonoBehaviour
{
    [SerializeField] GameObject prefabs;
    [SerializeField, Header("������")] int bulletNum;
    [SerializeField, Header("�N�[���^�C��")] float coolTime;
    [SerializeField, Header("������"), Tooltip("�������e�𐶐�����ꍇ�ɕ��������w�� ���͂�1�ȏ�")] int way = 1;
    [SerializeField, Header("�p�x")] float angle;
    [SerializeField, Header("�e��")] float speed;

    GameObject player;
    Vector3 playerPos;
    Vector3 direction;

    NormalBullet normalBullet;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        playerPos = player.transform.position;

        normalBullet = prefabs.GetComponent<NormalBullet>();
        normalBullet.speed = speed;

        direction = (playerPos - transform.position).normalized;

        StartCoroutine(Create());
    }

    void Update()
    {
        playerPos = player.transform.position;
        direction = (playerPos - transform.position).normalized;
    }

    IEnumerator Create()
    {
        for (int i = 0; i < bulletNum; i++)
        {
            for (int j = 0; j < way; j++)
            {
                GameObject obj = Instantiate(prefabs, this.transform.position, Quaternion.identity, gameObject.transform);

                float a = angle;
                if(way % 2 == 0)
                {
                    a = angle + ((angle / 2) * (j - 1));
                }
                if(way % 2 == 1)
                {
                    a = angle * (j - 1);
                }

                obj.GetComponent<NormalBullet>().angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + a;
            }
            yield return new WaitForSeconds(coolTime);
        }
    }
}
