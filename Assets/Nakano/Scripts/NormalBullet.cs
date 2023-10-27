using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 指定した方向に直線的に発射
/// </summary>
public class NormalBullet : MonoBehaviour
{
    [Header("発射方向"), Tooltip("角度0のとき右へ、角度180のとき左へ\n角度は三角関数のイメージで")] public float angle;
    [HideInInspector] public float speed;
    Vector3 direction;

    public bool isReflect = false;

    [HideInInspector] public int num = 0;

    void Start()
    {
        //角度を単位ベクトルに変える
        direction = AngleToVector3(angle);
    }

    void Update()
    {
        //角度を単位ベクトルに変える
        direction = AngleToVector3(angle);
        transform.Translate(direction * speed * Time.deltaTime);
    }

    /// <summary>
    /// 角度から単位ベクトルを取得
    /// </summary>
    Vector2 AngleToVector3(float angle)
    {
        var radian = angle * (Mathf.PI / 180);
        return new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0).normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "BigBullets" && isReflect)
        {
            direction *= -1;
            isReflect = false;
        }
    }
}
