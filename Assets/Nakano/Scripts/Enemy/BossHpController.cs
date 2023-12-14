using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHpController : MonoBehaviour
{
    [SerializeField] BossController bossController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!bossController.Invincible) //無敵状態でないとき
        {
            //プレイヤーの弾に当たったら
            if (collision.gameObject.tag == "PlayerBullet")
            {
                //HP減少　減少量は攻撃に応じて変化
                bossController.BossHp -= 100;
            }
        }
    }
}
