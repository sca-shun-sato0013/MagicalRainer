using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField, Header("初期HP")] float defaultHp;
    float hp;

    bool isBulletsDestroy; //弾消去フラグ

    public float BossHp
    {
        get { return hp; }
        set { hp = value; }
    }

    void Start()
    {
        hp = defaultHp;
    }

    void Update()
    {
        
    }

}
