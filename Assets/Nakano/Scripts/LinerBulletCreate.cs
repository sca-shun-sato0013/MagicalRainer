using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinerBulletCreate : MonoBehaviour
{
    [SerializeField] GameObject prefabs;
    [SerializeField, Header("’e‚Ì‰æ‘œ")] Sprite sprite;
    [SerializeField, Header("¶¬ŠÔ")] float createTime;
    //[SerializeField, Header("¶¬”")] int bulletNum;
    [SerializeField, Header("ƒN[ƒ‹ƒ^ƒCƒ€")] float coolTime;
    [SerializeField, Header("•ûŒü”"), Tooltip("‘½•ûŒü’e‚ğ¶¬‚·‚éê‡‚É•ûŒü”‚ğw’è “ü—Í‚Í1ˆÈã")] int way = 1;
    [SerializeField, Header("Šp“x")] float angle;
    [SerializeField, Header("’e‘¬")] float speed;

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

        prefabs.GetComponent<SpriteRenderer>().sprite = sprite;

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
