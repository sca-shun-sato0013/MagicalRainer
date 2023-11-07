using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 自機に向かって発射される弾を生成
/// </summary>
public class AimBulletCreate : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField, Header("AimBullet")] GameObject prefabs;
    [SerializeField, Header("生成数")] int bulletNum;
    [SerializeField, Header("クールタイム")] float coolTime;
    [SerializeField, Header("弾速")] float speed;

    AimBullet aimBullet;

    public bool isCreate = false;

    RectTransform rt;
    Vector3 pos;

    void Awake()
    {
        aimBullet = prefabs.GetComponent<AimBullet>();
        aimBullet.speed = speed;

        rt = transform.parent.GetComponent<RectTransform>();
    }

    void Update()
    {
        pos = GetWorldPositionFromRectPosition(rt);

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
            Instantiate(prefabs, this.transform.localPosition + pos, Quaternion.identity);
            yield return new WaitForSeconds(coolTime);
        }
    }

    private Vector3 GetWorldPositionFromRectPosition(RectTransform rect)
    {
        //UI座標からスクリーン座標に変換
        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, rect.position);

        //ワールド座標
        Vector3 result = Vector3.zero;

        //スクリーン座標→ワールド座標に変換
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rect, screenPos, canvas.worldCamera, out result);

        return result;
    }
}
