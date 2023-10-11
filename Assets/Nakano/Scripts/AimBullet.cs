using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimBullet : MonoBehaviour
{
    GameObject player;
    Vector3 playerPos;
    Vector3 bulletPos;

    Vector3 direction;
    Vector3 dirNormal;

    [SerializeField] float speed;

    void Start()
    {
        //生成時に自身の位置とプレイヤーの位置を取得する
        player = GameObject.FindWithTag("Player");
        playerPos = player.transform.position;
        bulletPos = this.transform.position;

        direction = playerPos - bulletPos;
        dirNormal = direction.normalized;

        Quaternion quaternion = Quaternion.LookRotation(direction);
    }

    void Update()
    {
        transform.Translate(dirNormal * speed * Time.deltaTime);
    }
}
