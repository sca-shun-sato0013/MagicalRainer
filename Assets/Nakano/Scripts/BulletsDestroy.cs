using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 画面外に出た弾を削除するスクリプトです
/// </summary>
public class BulletsDestroy : MonoBehaviour
{
    public bool isGather = false; //敵の位置に弾を集めるか
    public Vector3 enemyPos = new Vector3(0, 0, 0); //敵の位置
    public float dis = 0; //敵との距離

    void Start()
    {
        
    }

    void Update()
    {
        var pos = this.transform.position;
        if(pos.x < -970 || pos.x > 970 || pos.y < -550 || pos.y > 550)
        {
            Destroy(this.gameObject);
        }

        if (isGather && Vector3.Distance(this.transform.position, enemyPos) <= dis)
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
