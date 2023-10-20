using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hikkaki : MonoBehaviour
{
    [SerializeField] GameObject prefabs;

    [SerializeField, Header("��i�@�e�����ʒu"), Tooltip("�ݒ肵�����W���烉���_���ɒe�𐶐�����")] Vector3[] upPos;
    [SerializeField, Header("���i�@�e�����ʒu")] Vector3[] middlePos;
    [SerializeField, Header("���i�@�e�����ʒu")] Vector3[] downPos;

    [SerializeField, Header("��i�@������")] int upNum;
    [SerializeField, Header("���i�@������")] int middleNum;
    [SerializeField, Header("���i�@������")] int downNum;

    [SerializeField, Header("�e��")] float speed;

    NormalBullet normalBullet;

    public bool isCreate = false;

    void Awake()
    {
        normalBullet = prefabs.GetComponent<NormalBullet>();
        normalBullet.speed = speed;
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
        for(int i = 0; i < upNum; i++)
        {
            Vector3 pos = upPos[Random.Range(0, upPos.Length)];
            GameObject obj = Instantiate(prefabs, pos, Quaternion.identity);
            obj.GetComponent<NormalBullet>().angle = Random.Range(0, 361);
        }

        for (int i = 0; i < middleNum; i++)
        {
            Vector3 pos = middlePos[Random.Range(0, middlePos.Length)];
            GameObject obj = Instantiate(prefabs, pos, Quaternion.identity);
            obj.GetComponent<NormalBullet>().angle = Random.Range(0, 361);
        }

        for (int i = 0; i < downNum; i++)
        {
            Vector3 pos = downPos[Random.Range(0, downPos.Length)];
            GameObject obj = Instantiate(prefabs, pos, Quaternion.identity);
            obj.GetComponent<NormalBullet>().angle = Random.Range(0, 361);
        }

        yield return new WaitForEndOfFrame();
    }
}
