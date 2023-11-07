using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 弾生成込みの敵挙動の例です
/// </summary>
public class EnemySample : MonoBehaviour
{
    //生成したい弾に応じてNakano > Prefabs > BulletsCreateフォルダ内の適当なPrefabを敵オブジェクトの子オブジェクトとして追加してください

    //子オブジェクトを指定する 変数名はご自由に　SerializeFieldで指定するんじゃなくてGetChildメソッドとかで子オブジェクトを取得するでも良いです
    [SerializeField] GameObject bulletsCreate;

    //取得するScriptの宣言　付けるPrefabと同名のやつだけで良いです　どれを付けるかは仕様書を参照してください
    AimBulletCreate aim; 　　　　　//「自機に向かって」となっている場合　ステージ1/ノーマル/フェーズ1　など　プレハブのBigAimBulletCreate(同挙動の弾 大)を付けるときもこれで
    NormalBulletCreate normal;　　 //「自機は狙わず追尾もしない」場合　　ステージ2/ノーマル/フェーズ4　など　プレハブのBigNormalBulletCreate(同挙動の弾 大)を付けるときもこれで
    TrackingBulletCreate tracking; //「追尾する」場合　　　　　　　　　　ステージ2/ハード/フェーズ1　など
    LinerBulletCreate liner; 　　　//線状に発射する場合　　　　　　　　　ステージ2/ハード/フェーズ1/挙動2つ目

    //一回だけ処理するためのフラグ　ここらへんは上手いことやってください
    bool isTmp = true;

    void Start()
    {
        //宣言したScriptをGetComponentでbulletsCreateから取得
        //aim = bulletsCreate.GetComponent<AimBulletCreate>();
        //normal = bulletsCreate.GetComponent<NormalBulletCreate>();
        //tracking = bulletsCreate.GetComponent<TrackingBulletCreate>();
        liner = bulletsCreate.GetComponent<LinerBulletCreate>();

        //isCreate初期化
        //aim.isCreate = false;
        //normal.isCreate = false;
        //tracking.isCreate = false;
        liner.isCreate = false;

        isTmp = true;
    }

    void Update()
    {
        //this.transform.Rotate(0f, 0f, 1.0f);

        //移動
        //this.transform.Translate(Vector3.right * 5 * Time.deltaTime);
        
        //例として特定の位置まで行ったら弾を生成
        if(isTmp)
        {
            //aim.isCreate = true; //弾を生成するScriptのisCreateをtrueに　isCreateがtrueのときに設定した弾数を生成します
            //normal.isCreate = true;
            //tracking.isCreate = true;
            liner.isCreate = true;
            isTmp = false;
        }
    }
}
