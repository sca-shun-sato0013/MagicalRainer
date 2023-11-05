using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinerBulletCreate : MonoBehaviour
{
    [SerializeField, Header("NormalBullet")] GameObject prefabs;
    [SerializeField, Header("生成時間")] float createTime;
    //[SerializeField, Header("生成数")] int bulletNum;
    [SerializeField, Header("クールタイム")] float coolTime;
    [SerializeField, Header("方向数"), Tooltip("多方向弾を生成する場合に方向数を指定 入力は1以上")] int way = 1;
    [SerializeField, Header("角度")] float angle;
    [SerializeField, Header("弾速")] float speed;

    GameObject player;
    Vector3 playerPos;
    Vector3 direction;

    NormalBullet normalBullet;

    public bool isCreate = false;

    float t = 0;
    bool isCount = false;


    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        playerPos = player.transform.position;

        normalBullet = prefabs.GetComponent<NormalBullet>();
        normalBullet.speed = speed;

        direction = (playerPos - transform.position).normalized;
    }

    void Update()
    {
        if (isCreate)
        {
            isCreate = false;
            isCount = true;
            t = 0;
            StartCoroutine(Create());
        }
        playerPos = player.transform.position;
        direction = (playerPos - transform.position).normalized;

        if (isCount)
        {
            t += Time.deltaTime;
        }
    }

    IEnumerator Create()
    {
        while (t < createTime)
        {
            for (int j = 0; j < way; j++)
            {
                GameObject obj = Instantiate(prefabs, this.transform.position, Quaternion.identity);

                float a = angle;
                if(way % 2 == 0)
                {
                    a = angle + ((angle / 2) * (j - 1));
                }
                if(way % 2 == 1)
                {
                    a = angle * (j - 1);
                }

                obj.GetComponent<NormalBullet>().angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + a;
            }
            yield return new WaitForSeconds(coolTime);
        }
        isCount = false;
    }
}
