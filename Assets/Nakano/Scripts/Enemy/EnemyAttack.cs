using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float attack;

    public float Attack
    {
        get { return attack; }
        set { attack = value; }
    }
}
