using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �w�肵���p�x�͈͓̔��Ń����_���ɒe�𐶐����܂�
/// </summary>
public class RandomBulletCreate : MonoBehaviour
{
    [SerializeField, Header("NormalBullet")] GameObject prefabs;
    [SerializeField, Header("������")] int bulletNum;
    [SerializeField, Header("������")] int createNum;
    [SerializeField, Header("��񐶐����̃N�[���^�C�����")] float upperLimit;
    [SerializeField, Header("��񐶐����̃N�[���^�C������")] float lowerLimit;
    [SerializeField, Header("�N�[���^�C��")] float coolTime;
    [SerializeField, Header("�p�x"), Tooltip("�e�̐��ʂ��獶�E��angle/2�͈̔͂Ƀ����_����������")] float angle;
    [SerializeField, Header("�e��")] float speed;

    GameObject player;
    Vector3 playerPos;
    Vector3 mainDirection;

    NormalBullet normalBullet;

    public bool isCreate = false;
    bool tmp = false;
    int count = 0;

    Canvas canvas;
    RectTransform rt;
    Vector3 pos;
    TransformChange tc = new();

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerPos = player.transform.position;

        normalBullet = prefabs.GetComponent<NormalBullet>();
        normalBullet.speed = speed;

        mainDirection = (playerPos - transform.position).normalized;

        canvas = GameObject.FindWithTag("Canvas").GetComponent<Canvas>();
        rt = GetComponent<RectTransform>();
    }

    void Update()
    {
        pos = tc.PositionChange(rt, canvas);

        if (!isCreate) { count = 0; }
        if (isCreate)
        {
            count++;
            if (count == 1)
            {
                tmp = true;
            }
        }

        if (tmp)
        {
            tmp = false;
            StartCoroutine(Create());
        }

        playerPos = player.transform.position;
        mainDirection = (playerPos - transform.position).normalized;
    }

    IEnumerator Create()
    {
        for (int j = 0; j < createNum; j++)
        {
            for (int i = 0; i < bulletNum; i++)
            {
                GameObject obj = Instantiate(prefabs, pos, Quaternion.identity);
                var ranAngle = Random.Range(-angle / 2, angle / 2);
                obj.GetComponent<NormalBullet>().angle = Mathf.Atan2(mainDirection.y, mainDirection.x) * Mathf.Rad2Deg + ranAngle;
                var c = Random.Range(lowerLimit, upperLimit);
                yield return new WaitForSeconds(c);
            }

            yield return new WaitForSeconds(coolTime);
        }
    }
}
