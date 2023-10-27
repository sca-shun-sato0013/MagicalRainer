using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 自機に向かって発射される弾を生成
/// </summary>
public class AimBulletCreate : MonoBehaviour
{
    [SerializeField] GameObject prefabs;
    [SerializeField, Header("弾の画像")] Sprite sprite;
    [SerializeField, Header("生成数")] int bulletNum;
    [SerializeField, Header("クールタイム")] float coolTime;
    [SerializeField, Header("弾速")] float speed;

    AimBullet aimBullet;

    public bool isCreate = false;

    void Awake()
    {
        aimBullet = prefabs.GetComponent<AimBullet>();
        aimBullet.speed = speed;
        prefabs.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    void Update()
    {
        if(isCreate)
        {
            isCreate = false;
            StartCoroutine(Create());
        }
    }

    IEnumerator Create()
    {
        for (int i = 0; i < bulletNum; i++)
        {
            Instantiate(prefabs, this.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(coolTime);
        }
    }
}
