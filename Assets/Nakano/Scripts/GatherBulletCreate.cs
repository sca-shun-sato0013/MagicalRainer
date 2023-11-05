using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherBulletCreate : MonoBehaviour
{
    [SerializeField, Header("NormalBullet")] GameObject prefabs;
    [SerializeField, Header("ˆê•Ó‚Ì¶¬”")] int bulletNum;
    [SerializeField, Header("¶¬ŠÔ")] float createTime;
    //[SerializeField, Header("¶¬‰ñ”")] int createNum;
    [SerializeField, Header("ƒN[ƒ‹ƒ^ƒCƒ€"), Tooltip("’Z‚¢‚Ù‚Ç–§“x‚ªã‚ª‚é")] float coolTime;
    [SerializeField, Header("’e‘¬")] float speed;

    [SerializeField, Header("“G‚Æ‚Ì‹——£‚ªdisˆÈ‰º‚Ì‚Æ‚«’e‚ğíœ")] float dis;

    NormalBullet normalBullet;
    BulletsDestroy bulletsDestroy;

    Vector3 direction;
    float range;

    public bool isCreate = false;

    float t = 0;
    bool isCount = false;

    void Awake()
    {
        normalBullet = prefabs.GetComponent<NormalBullet>();
        normalBullet.speed = speed;
        normalBullet.isReflect = true;

        bulletsDestroy = prefabs.GetComponent<BulletsDestroy>();
        bulletsDestroy.isGather = true;
        bulletsDestroy.enemyPos = this.transform.position;
        bulletsDestroy.dis = dis;
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

        if (isCount)
        {
            t += Time.deltaTime;
        }
    }

    IEnumerator Create()
    {
        while (t < createTime)
        {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < bulletNum; i++)
                {
                    Vector3 createPos = new Vector3(0, 0, 0);
                    switch (j)
                    {
                        case 0:
                            createPos.x = Random.Range(-15, 16);
                            createPos.y = Random.Range(11, 12);
                            break;
                        case 1:
                            createPos.x = Random.Range(-15, 16);
                            createPos.y = Random.Range(-15, -12);
                            break;
                        case 2:
                            createPos.x = Random.Range(-15, -12);
                            createPos.y = Random.Range(-11, 12);
                            break;
                        case 3:
                            createPos.x = Random.Range(11, 12);
                            createPos.y = Random.Range(-11, 12);
                            break;
                        default:
                            break;
                    }

                    GameObject obj = Instantiate(prefabs, createPos, Quaternion.identity);
                    direction = (this.transform.position - obj.transform.position).normalized;
                    obj.GetComponent<NormalBullet>().angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                }
            }
            yield return new WaitForSeconds(coolTime);
        }
        isCount = false;
    }
}