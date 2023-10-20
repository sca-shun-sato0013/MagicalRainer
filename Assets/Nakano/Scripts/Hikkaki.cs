using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hikkaki : MonoBehaviour
{
    [SerializeField] GameObject prefabs;

    [SerializeField, Header("上段　弾生成位置"), Tooltip("設定した座標からランダムに弾を生成する")] Vector3[] upPos;
    [SerializeField, Header("中段　弾生成位置")] Vector3[] middlePos;
    [SerializeField, Header("下段　弾生成位置")] Vector3[] downPos;

    [SerializeField, Header("上段　生成数")] int upNum;
    [SerializeField, Header("中段　生成数")] int middleNum;
    [SerializeField, Header("下段　生成数")] int downNum;

    [SerializeField, Header("弾速")] float speed;

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
