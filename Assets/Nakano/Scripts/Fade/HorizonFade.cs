using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HorizonFade : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rt.localPosition = new Vector3(0, 0, 0);
            isFadeOut = true;
            isFadeIn = false;
        }

        if (isFadeOut)
        {
            FadeOut();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            rt.localPosition = new Vector3(-2000, 0, 0);
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
        if(rt.localPosition.x < 2000)
        {
            rt.Translate(speed * Time.deltaTime, 0, 0);
        }
        else if(rt.localPosition.x >= 2000)
        {
            rt.localPosition = new Vector3(2000, 0, 0);
            isFadeOut = false;
        }
    }

    void FadeIn()
    {
        if (rt.localPosition.x < 0)
        {
            rt.Translate(speed * Time.deltaTime, 0, 0);
        }
        else if (rt.localPosition.x >= 0)
        {
            rt.localPosition = new Vector3(0, 0, 0);
            isFadeIn = false;
        }
    }
}
