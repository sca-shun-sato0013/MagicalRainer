using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnBulletCreate : MonoBehaviour
{
    [SerializeField, Header("NormalBullet")] GameObject prefabs;
    [SerializeField, Header("������")] int bulletNum;
    [SerializeField, Header("�N�[���^�C��")] float coolTime;
    [SerializeField, Header("�e��")] float speed;

    [SerializeField, Header("�p�x"), Tooltip("NormalBullets�Ŏw�肵���p�x���D�悳���")] float angle = 0;
    [SerializeField, Header("�c��"), Tooltip("���ɉ����Ԃ�(�c�������邩) ���͂�1�ȏ�")] int way = 1;
    [SerializeField, Header("�c�񓯎m�̋���")] float distance;

    NormalBullet normalBullet;

    public bool isCreate = false;

    void Start()
    {
        normalBullet = prefabs.GetComponent<NormalBullet>();
        normalBullet.speed = speed;

        if (way < 1) { way = 1; } //�w�肳�ꂽway��1�����̂Ƃ��A1�ɂ���

    }

    void Update()
    {
        if (isCreate)
        {
            isCreate = false;
            StartCoroutine(Create());
        }
    }

    IEnumerator Create()
    {
        for (int i = 0; i < bulletNum; i++)
        {
            if(way % 2 == 1)
            {
                for (int j = 0 - ((int)way / 2); j <= (way - ((int)way / 2) - 1); j++)
                {
                    GameObject obj = Instantiate(prefabs, this.transform.position + new Vector3(j * distance, 0, 0), Quaternion.identity);
                    obj.GetComponent<NormalBullet>().angle = angle;
                }
            }
            else if(way % 2 == 0)
            {
                for (int j = 0 - ((int)way / 2); j <= (way - ((int)way / 2)); j++)
                {
                    if(j < 0)
                    {
                        GameObject obj = Instantiate(prefabs, this.transform.position + new Vector3((j + 0.5f) * distance, 0, 0), Quaternion.identity);
                        obj.GetComponent<NormalBullet>().angle = angle;
                    }
                    else if(j >= 0)
                    {
                        GameObject obj = Instantiate(prefabs, this.transform.position + new Vector3((j - 0.5f) * distance, 0, 0), Quaternion.identity);
                        obj.GetComponent<NormalBullet>().angle = angle;
                    }
                }
            }
            
            yield return new WaitForSeconds(coolTime);
        }
    }
}
