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
        var pos = this.transform.position;
        if(pos.x < -20 || pos.x > 20 || pos.y < -20 || pos.y > 20)
        {
            Destroy(this.gameObject);
        }
    }

    //画面外に出たら
    //private void OnBecameInvisible()
    //{
    //    Destroy(this.gameObject);
    //}
}
