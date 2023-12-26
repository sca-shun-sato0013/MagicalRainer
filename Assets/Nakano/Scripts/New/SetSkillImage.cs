using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPattern;
using CommonlyUsed;
using UnityEngine.UI;

public class SetSkillImage : MonoBehaviour
{
    [SerializeField]
    Image[] skillImages;

    // Start is called before the first frame update
    void Start()
    {
        int index = 0;

        foreach(var img in skillImages)
        {
            ImageLoading.ImageLoadingAsync(img, Singleton<SkillData>.Instance.SelectSkillData[index]);
            index++;
        }
    }
}
