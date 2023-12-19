using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] ParticleSystem deathEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerBullet")) //タグ要変更
        {
            Instantiate(deathEffect, this.gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}