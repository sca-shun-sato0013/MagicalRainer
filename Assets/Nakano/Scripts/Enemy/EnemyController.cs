using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] ParticleSystem deathEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("当たった"+gameObject.name+collision.tag);
        if(collision.CompareTag("SingleAttack") || collision.CompareTag("LightAttack") || collision.CompareTag("HeavyAttack"))
        {
            Debug.Log("通った" + gameObject.name);
            Instantiate(deathEffect, this.gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}