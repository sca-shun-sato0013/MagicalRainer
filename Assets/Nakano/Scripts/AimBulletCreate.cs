using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 自機に向かって発射される弾を生成
/// </summary>
public class AimBulletCreate : MonoBehaviour
{
    [SerializeField] GameObject prefabs;
    [SerializeField, Header("生成数")] int bulletNum;
    [SerializeField, Header("クールタイム")] float coolTime;
    [SerializeField, Header("弾速")] float speed;

    AimBullet aimBullet;

    void Awake()
    {
        aimBullet = prefabs.GetComponent<AimBullet>();
        aimBullet.speed = speed;

        StartCoroutine(Create());
    }

    void Update()
    {
    }

    IEnumerator Create()
    {
        for (int i = 0; i < bulletNum; i++)
        {
            Instantiate(prefabs, this.transform.position, Quaternion.identity, gameObject.transform);
            yield return new WaitForSeconds(coolTime);
        }
    }
}
