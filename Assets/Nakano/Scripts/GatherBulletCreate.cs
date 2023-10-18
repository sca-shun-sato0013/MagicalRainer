using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherBulletCreate : MonoBehaviour
{
    [SerializeField] GameObject prefabs;
    [SerializeField, Header("一辺の生成数")] int bulletNum;
    [SerializeField, Header("生成回数")] int createNum;
    [SerializeField, Header("クールタイム")] float coolTime;
    [SerializeField, Header("弾速")] float speed;
    
    NormalBullet normalBullet;

    Vector3 direction;
    float range;

    public bool isCreate = false;

    void Awake()
    {
        normalBullet = prefabs.GetComponent<NormalBullet>();
        normalBullet.speed = speed;
        normalBullet.isReflect = true;
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
        for(int k = 0; k < createNum; k++)
        {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < bulletNum; i++)
                {
                    Vector3 createPos = new Vector3(0, 0, 0);
                    switch (j)
                    {
                        case 0:
                            createPos.x = Random.Range(-15, 16);
                            createPos.y = Random.Range(11, 12);
                            break;
                        case 1:
                            createPos.x = Random.Range(-15, 16);
                            createPos.y = Random.Range(-15, -12);
                            break;
                        case 2:
                            createPos.x = Random.Range(-15, -12);
                            createPos.y = Random.Range(-11, 12);
                            break;
                        case 3:
                            createPos.x = Random.Range(11, 12);
                            createPos.y = Random.Range(-11, 12);
                            break;
                        default:
                            break;
                    }

                    GameObject obj = Instantiate(prefabs, createPos, Quaternion.identity);
                    direction = (this.transform.position - obj.transform.position).normalized;
                    obj.GetComponent<NormalBullet>().angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                }
            }
            yield return new WaitForSeconds(coolTime);
        }
    }
}