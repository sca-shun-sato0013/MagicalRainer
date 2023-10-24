using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hikkaki : MonoBehaviour
{
    [SerializeField] GameObject prefabs;

    [SerializeField, Header("上段　生成数")] int upNum;
    [SerializeField, Header("中段　生成数")] int middleNum;
    [SerializeField, Header("下段　生成数")] int downNum;

    [SerializeField, Header("弾速")] float speed;

    NormalBullet normalBullet;

    public bool isCreate = false;

    GameObject[] posEdit;
    List<Vector3> upPosList = new();
    List<Vector3> middlePosList = new();
    List<Vector3> downPosList = new();

    [SerializeField, Header("trueのとき位置調整モードになる")] private bool isEdit;

    void Awake()
    {
        normalBullet = prefabs.GetComponent<NormalBullet>();
        normalBullet.speed = speed;

        posEdit = GameObject.FindGameObjectsWithTag("PosEdit");
        foreach (GameObject obj in posEdit)
        {
            PositionEdit pos = obj.GetComponent<PositionEdit>();
            if(pos.num == 1) //設定番号が1のときは上段
            {
                upPosList.Add(pos.gameObject.transform.position); //生成座標の配列に入れる
            }
            else if (pos.num == 2) //設定番号が2のときは中段
            {
                middlePosList.Add(pos.gameObject.transform.position);
            }
            else if (pos.num == 3) //設定番号が3のときは下段
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
