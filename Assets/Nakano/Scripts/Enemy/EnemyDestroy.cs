using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerBullets")) //�^�O�v�ύX
        {
            Destroy(this);
        }
    }
}