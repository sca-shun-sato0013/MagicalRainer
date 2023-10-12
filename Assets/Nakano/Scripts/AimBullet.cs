using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Playerを狙って発射　追尾はしない
/// </summary>
public class AimBullet : MonoBehaviour
{
    GameObject player;
    Vector3 playerPos;
    Vector3 bulletPos;

    Vector3 direction;

    [SerializeField, Header("弾速")] float speed;

    void Start()
    {
        //生成時に自身の位置とプレイヤーの位置を取得する
        player = GameObject.FindWithTag("Player");
        playerPos = player.transform.position;
        bulletPos = this.transform.position;

        direction = (playerPos - bulletPos).normalized;

        Quaternion quaternion = Quaternion.LookRotation(direction);
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
