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
        
    }

    //��ʊO�ɏo����
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
