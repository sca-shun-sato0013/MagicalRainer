using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerBullet")) //タグ要変更
        {
            Destroy(this);
        }

        if(collision.CompareTag("Bullets"))
        {
            Debug.Log("test");
        }
    }
}