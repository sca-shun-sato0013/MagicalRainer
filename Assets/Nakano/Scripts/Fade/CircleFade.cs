using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleFade : MonoBehaviour
{
    [SerializeField] Image unMask;
    RectTransform rt;
    [SerializeField, Header("フェード速度")] float speed;
    bool isFadeOut = false;
    bool isFadeIn = false;

    void Start()
    {
        rt = unMask.GetComponent<RectTransform>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rt.localScale = new Vector3(22, 22, 22);
            isFadeOut = true;
            isFadeIn = false;
        }

        if(isFadeOut)
        {
            FadeOut();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            rt.localScale = new Vector3(0, 0, 0);
            isFadeIn = true;
            isFadeOut = false;
        }

        if (isFadeIn)
        {
            FadeIn();
        }
    }

    void FadeOut()
    {
        if(rt.localScale.x > 0)
        {
            Vector3 v = new Vector3(1, 1, 1) * speed;
            rt.localScale -= v * Time.deltaTime;
        }
        else if(rt.localScale.x <= 0)
        {
            rt.localScale = new Vector3(0, 0, 0);
            isFadeOut = false;
        }
    }

    void FadeIn()
    {
        if (rt.localScale.x < 22)
        {
            Vector3 v = new Vector3(1, 1, 1) * speed;
            rt.localScale += v * Time.deltaTime;
        }
        else if (rt.localScale.x >= 22)
        {
            rt.localScale = new Vector3(22, 22, 22);
            isFadeIn = false;
        }
    }
}
