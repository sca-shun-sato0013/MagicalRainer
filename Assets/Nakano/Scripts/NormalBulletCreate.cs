using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBulletCreate : MonoBehaviour
{
    [SerializeField, Header("NormalBullet")] GameObject prefabs;
    [SerializeField, Header("¶¬ŠÔ")] float createTime;
    //[SerializeField, Header("¶¬”")] int bulletNum;
    [SerializeField, Header("ƒN[ƒ‹ƒ^ƒCƒ€")] float coolTime;
    [SerializeField, Header("’e‘¬")] float speed;

    [SerializeField, Header("Šp“x"), Tooltip("NormalBullets‚Åw’è‚µ‚½Šp“x‚æ‚è—Dæ‚³‚ê‚é")] float angle = 0;
    [SerializeField, Header("•ûŒü”"), Tooltip("‘½•ûŒü’e‚ğ¶¬‚·‚éê‡‚É•ûŒü”‚ğw’è Šp“x‚Íİ’è‚µ‚Ä‚à–³ˆÓ–¡‚É‚È‚é “ü—Í‚Í1ˆÈã")] int way = 1;
    [SerializeField, Header("Šp“x’²®"), Tooltip("‘½•ûŒü’e‚ÌŠp“x‚ğ’²®‚·‚é")] float adjustmentAngle = 0; 
    float parentAngle;

    GameObject parent;
    NormalBullet normalBullet;

    public bool isCreate = false;

    float t = 0;
    bool isCount = false;

    Canvas canvas;
    RectTransform rt;
    Vector3 pos;
    TransformChange tc = new();

    void Awake()
    {
        parent = transform.parent.gameObject;
        parentAngle = parent.GetComponent<Transform>().localEulerAngles.z;

        //‘¬“xİ’è
        normalBullet = prefabs.GetComponent<NormalBullet>();
        normalBullet.speed = speed;

        if (way < 1) { way = 1; } //w’è‚³‚ê‚½way‚ª1–¢–‚Ì‚Æ‚«A1‚É‚·‚é

        //‘½•ûŒü’e‚Ì‚Æ‚«A’e“¯m‚ÌŠÔ‚ÌŠp“x‚ğZo
        if (way > 1) { angle = 360 / way; }
        else { adjustmentAngle = 0; }

        canvas = GameObject.FindWithTag("Canvas").GetComponent<Canvas>();
        rt = GetComponent<RectTransform>();
    }

    void Update()
    {
        pos = tc.PositionChange(rt, canvas);

        if (isCreate)
        {
            isCreate = false;
            isCount = true;
            t = 0;
            StartCoroutine(Create());
        }

        if(isCount)
        {
            t += Time.deltaTime;
        }
    }

    IEnumerator Create()
    {
        while (t < createTime)
        {
            for (int j = 1; j <= way; j++)
            {
                GameObject obj = Instantiate(prefabs, pos, Quaternion.identity);
                parentAngle = parent.GetComponent<RectTransform>().rotation.z;
                obj.GetComponent<NormalBullet>().angle = angle * j + adjustmentAngle + parentAngle;
            }
            yield return new WaitForSeconds(coolTime);
        }
        isCount = false;
    }
}
