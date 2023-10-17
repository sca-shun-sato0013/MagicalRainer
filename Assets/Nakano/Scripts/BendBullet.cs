using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BendBullet : MonoBehaviour
{
    float time;
    Vector3 startPos;
    Vector3 relayPos;
    Vector3 targetPos;

    [HideInInspector] public Vector2 relayAjust;
    [HideInInspector] public Vector2 targetAjust;

    [Header("発射方向")] public float angle;
    [HideInInspector] public float speed;

    void Start()
    {
        startPos = this.transform.position;
        relayPos = Quaternion.Euler(0, 0, angle) * new Vector3(startPos.x + relayAjust.x, startPos.y + relayAjust.y, 0);
        targetPos = Quaternion.Euler(0, 0, angle) * new Vector3(startPos.x + targetAjust.x, startPos.y + targetAjust.y);
    }

    void Update()
    {
        //弾の進行具合（Lerpの第三引数に入れる）
        time += Time.deltaTime;
        //二次ベジェ曲線を使う
        //スタートから中継地点をつなぐベクトル上を走る点の位置
        var firstVec = Vector3.Lerp(startPos, relayPos, time / speed);
        //中継地点からターゲットまでをつなぐベクトル上を走る点の位置
        var SecondVec = Vector3.Lerp(relayPos, targetPos, time / speed);
        //上の二点をつなぐベクトル上を走る点（弾）の位置
        var vec = Vector3.Lerp(firstVec, SecondVec, time / speed);
        //弾の位置を代入する
        this.transform.position = vec;
    }
}
