using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 自機に向かって発射される弾を生成
/// </summary>
public class AimBulletCreate : MonoBehaviour
{
    [SerializeField, Header("AimBullet")] GameObject prefabs;
    [SerializeField, Header("生成数")] int bulletNum;
    [SerializeField, Header("クールタイム")] float coolTime;
    [SerializeField, Header("弾速")] float speed;

    [SerializeField, Header("縦列発射するか")] bool isColumn;
    [SerializeField, Header("縦列数"), Tooltip("横に何個並ぶか(縦列を何個作るか) 入力は1以上")] int way = 1;
    [SerializeField, Header("縦列同士の距離")] float distance;

    [SerializeField, Header("全弾同時生成")] bool isAll = false;
    [SerializeField, Header("全弾同時生成時の弾間の距離 クールタイムの代わり")] float dis;

    AimBullet aimBullet;

    public bool isCreate = false;
    bool tmp = false;
    int count = 0;

    Canvas canvas;
    RectTransform rt;
    Vector3 pos;
    TransformChange tc;

    void Awake()
    {
        tc = gameObject.AddComponent<TransformChange>();
        aimBullet = prefabs.GetComponent<AimBullet>();
        aimBullet.speed = speed;

        canvas = GameObject.FindWithTag("Canvas").GetComponent<Canvas>();
        rt = GetComponent<RectTransform>();

        if (way < 1) { way = 1; } //指定されたwayが1未満のとき、1にする
    }

    void Update()
    {
        pos = tc.PositionChange(rt, canvas);

        if(!isCreate) { count = 0;}
        if (isCreate)
        {
            count++;
            if(count == 1)
            {
                tmp = true;
            }
        }

        if(tmp)
        {
            tmp = false;
            StartCoroutine(Create());
        }
    }

    IEnumerator Create()
    {
        if (!isColumn)
        {
            for (int i = 0; i < bulletNum; i++)
            {
                Instantiate(prefabs, pos, Quaternion.identity);
                yield return new WaitForSeconds(coolTime);
            }
        }
        else if (isColumn)
        {
            float d = 0;
            for (int i = 0; i < bulletNum; i++)
            {
                if (way % 2 == 1)
                {
                    for (int j = 0 - ((int)way / 2); j <= (way - ((int)way / 2) - 1); j++)
                    {
                        Instantiate(prefabs, pos + new Vector3(j * distance, d, 0), Quaternion.identity);
                    }
                }
                else if (way % 2 == 0)
                {
                    for (int j = 0 - ((int)way / 2); j <= (way - ((int)way / 2)); j++)
                    {
                        if (j < 0)
                        {
                            Instantiate(prefabs, (pos + new Vector3((j + 0.5f) * distance, d, 0)), Quaternion.identity);
                        }
                        else if (j >= 0)
                        {
                            Instantiate(prefabs, (pos + new Vector3((j - 0.5f) * distance, d, 0)), Quaternion.identity);
                        }
                    }
                }

                if (!isAll)
                {
                    yield return new WaitForSeconds(coolTime);
                }
                else { d += dis; }
            }
        }
    }
}
