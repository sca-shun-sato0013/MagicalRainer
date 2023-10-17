using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 画面外に出た弾を削除するスクリプトです
/// </summary>
public class BulletsDestroy : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //画面外に出たら
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
