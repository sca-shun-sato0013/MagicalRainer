using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField, Header("����HP")] float defaultHp;
    float hp;

    bool isBulletsDestroy; //�e�����t���O

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
