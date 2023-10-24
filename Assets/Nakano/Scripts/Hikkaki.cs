using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hikkaki : MonoBehaviour
{
    [SerializeField] GameObject prefabs;

    [SerializeField, Header("��i�@������")] int upNum;
    [SerializeField, Header("���i�@������")] int middleNum;
    [SerializeField, Header("���i�@������")] int downNum;

    [SerializeField, Header("�e��")] float speed;

    NormalBullet normalBullet;

    public bool isCreate = false;

    GameObject[] posEdit;
    List<Vector3> upPosList = new();
    List<Vector3> middlePosList = new();
    List<Vector3> downPosList = new();

    [SerializeField, Header("true�̂Ƃ��ʒu�������[�h�ɂȂ�")] private bool isEdit;

    void Awake()
    {
        normalBullet = prefabs.GetComponent<NormalBullet>();
        normalBullet.speed = speed;

        posEdit = GameObject.FindGameObjectsWithTag("PosEdit");
        foreach (GameObject obj in posEdit)
        {
            PositionEdit pos = obj.GetComponent<PositionEdit>();
            if(pos.num == 1) //�ݒ�ԍ���1�̂Ƃ��͏�i
            {
                upPosList.Add(pos.gameObject.transform.position); //�������W�̔z��ɓ����
            }
            else if (pos.num == 2) //�ݒ�ԍ���2�̂Ƃ��͒��i
            {
                middlePosList.Add(pos.gameObject.transform.position);
            }
            else if (pos.num == 3) //�ݒ�ԍ���3�̂Ƃ��͉��i
            {
                downPosList.Add(pos.gameObject.transform.position);
            }
        }
        
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
            Vector3 pos = upPosList[Random.Range(0, upPosList.Count)];
            GameObject obj = Instantiate(prefabs, pos, Quaternion.identity);
            obj.GetComponent<NormalBullet>().angle = Random.Range(0, 361);
        }

        for (int i = 0; i < middleNum; i++)
        {
            Vector3 pos = middlePosList[Random.Range(0, middlePosList.Count)];
            GameObject obj = Instantiate(prefabs, pos, Quaternion.identity);
            obj.GetComponent<NormalBullet>().angle = Random.Range(0, 361);
        }

        for (int i = 0; i < downNum; i++)
        {
            Vector3 pos = downPosList[Random.Range(0, downPosList.Count)];
            GameObject obj = Instantiate(prefabs, pos, Quaternion.identity);
            obj.GetComponent<NormalBullet>().angle = Random.Range(0, 361);
        }

        yield return new WaitForEndOfFrame();
    }
}
