using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ʊO�ɏo���e���폜����X�N���v�g�ł�
/// </summary>
public class BulletsDestroy : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        var pos = this.transform.position;
        if(pos.x < -20 || pos.x > 20 || pos.y < -20 || pos.y > 20)
        {
            Destroy(this.gameObject);
        }
    }

    //��ʊO�ɏo����
    //private void OnBecameInvisible()
    //{
    //    Destroy(this.gameObject);
    //}
}
