using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BendBulletCreate : MonoBehaviour
{
    [SerializeField, Header("BendBullet")] GameObject prefabs;
    [SerializeField, Header("生成時間")] float createTime;
    //[SerializeField, Header("生成数")] int bulletNum;
    [SerializeField, Header("クールタイム")] float coolTime;
    [SerializeField, Header("弾速　【注意】他と異なり値が高いほど低速化")] float speed;

    [SerializeField, Header("角度"), Tooltip("BendBulletsで指定した角度より優先される")] float angle = 0;
    [SerializeField, Header("方向数"), Tooltip("多方向弾を生成する場合に方向数を指定 角度は設定しても無意味になる 入力は1以上")] int way = 1;
    [SerializeField, Header("角度調整"), Tooltip("多方向弾の角度を調整する")] float adjustmentAngle = 0;

    [SerializeField, Header("角度調整"), Tooltip("ベジェ曲線の高さを調整")] Vector2 relayAjust = new Vector2(100, 300);
    [SerializeField, Header("到達地点調整"), Tooltip("ベジェ曲線の最終位置を調整")] Vector2 targetAjust = new Vector2(200, -900);

    BendBullet bendBullet;

    public bool isCreate = false;
    [Header("逆回転にするかどうか")] public bool isReverse = false;

    float t = 0;
    bool isCount = false;

    Canvas canvas;
    RectTransform rt;
    Vector3 pos;
    TransformChange tc = new();

    private void Awake()
    {
        bendBullet = prefabs.GetComponent<BendBullet>();
        bendBullet.speed = speed;

        if (!isReverse)
        {
            bendBullet.relayAjust = relayAjust;
            bendBullet.targetAjust = targetAjust;
        }
        if(isReverse)
        {
            bendBullet.relayAjust = new Vector2(relayAjust.x * -1, relayAjust.y);
            bendBullet.targetAjust = new Vector2(targetAjust.x * -1, targetAjust.y);
        }

        if (way < 1) { way = 1; } //指定されたwayが1未満のとき、1にする

        //多方向弾のとき、弾同士の間の角度を算出
        if (way > 1) { angle = 360 / way; }
        else { adjustmentAngle = 0; }

        canvas = GameObject.FindWithTag("Canvas").GetComponent<Canvas>();
        rt = GetComponent<RectTransform>();
    }

    void Update()
    {
        pos = tc.PositionChange(rt, canvas);

        if (isCreate)
        {
            isCreate = false;
            isCount = true;
            t = 0;
            StartCoroutine(Create());
        }

        if (isCount)
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
                GameObject obj = Instantiate(prefabs, pos, Quaternion.identity);
                obj.GetComponent<BendBullet>().angle = angle * j + adjustmentAngle;
            }
            yield return new WaitForSeconds(coolTime);
        }
        isCount = false;
    }
}
