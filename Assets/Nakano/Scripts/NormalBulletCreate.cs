using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBulletCreate : MonoBehaviour
{
    [SerializeField, Header("NormalBullet")] GameObject prefabs;
    [SerializeField, Header("生成時間")] float createTime;
    //[SerializeField, Header("生成数")] int bulletNum;
    [SerializeField, Header("クールタイム")] float coolTime;
    [SerializeField, Header("弾速")] float speed;

    [SerializeField, Header("角度"), Tooltip("NormalBulletsで指定した角度より優先される")] float angle = 0;
    [SerializeField, Header("方向数"), Tooltip("多方向弾を生成する場合に方向数を指定 角度は設定しても無意味になる 入力は1以上")] int way = 1;
    [SerializeField, Header("角度調整"), Tooltip("多方向弾の角度を調整する")] float adjustmentAngle = 0; 
    float parentAngle;

    GameObject parent;
    NormalBullet normalBullet;

    public bool isCreate = false;

    float t = 0;
    bool isCount = false;

    void Awake()
    {
        parent = transform.parent.gameObject;
        parentAngle = parent.GetComponent<Transform>().localEulerAngles.z;

        //速度設定
        normalBullet = prefabs.GetComponent<NormalBullet>();
        normalBullet.speed = speed;

        if (way < 1) { way = 1; } //指定されたwayが1未満のとき、1にする

        //多方向弾のとき、弾同士の間の角度を算出
        if (way > 1) { angle = 360 / way; }
        else { adjustmentAngle = 0; }
    }

    void Update()
    {
        if (isCreate)
        {
            isCreate = false;
            isCount = true;
            t = 0;
            StartCoroutine(Create());
        }

        if(isCount)
        {
            t += Time.deltaTime;
        }
    }

    IEnumerator Create()
    {
        while (t < createTime)
        {
            for (int j = 1; j <= way; j++)
            {
                GameObject obj = Instantiate(prefabs, this.transform.position, Quaternion.identity);
                parentAngle = parent.GetComponent<Transform>().localEulerAngles.z;
                obj.GetComponent<NormalBullet>().angle = angle * j + adjustmentAngle + parentAngle;
            }
            yield return new WaitForSeconds(coolTime);
        }
        isCount = false;
    }
}
