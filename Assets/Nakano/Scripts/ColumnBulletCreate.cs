using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnBulletCreate : MonoBehaviour
{
    [SerializeField] GameObject prefabs;
    [SerializeField, Header("生成数")] int bulletNum;
    [SerializeField, Header("クールタイム")] float coolTime;
    [SerializeField, Header("弾速")] float speed;

    [SerializeField, Header("角度"), Tooltip("NormalBulletsで指定した角度より優先される")] float angle = 0;
    [SerializeField, Header("縦列数"), Tooltip("横に何個並ぶか(縦列を何個作るか) 入力は1以上")] int way = 1;
    [SerializeField, Header("縦列同士の距離")] float distance;

    NormalBullet normalBullet;

    public bool isCreate = false;

    void Start()
    {
        normalBullet = prefabs.GetComponent<NormalBullet>();
        normalBullet.speed = speed;
        if (way < 1) { way = 1; } //指定されたwayが1未満のとき、1にする

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
