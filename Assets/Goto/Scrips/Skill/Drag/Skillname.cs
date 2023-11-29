using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Skillname : MonoBehaviour
{
    [SerializeField]
    string skillset;
    string  skillname;
    // [SerializeField] private GameObject TargetSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        GameObject obj = collision.gameObject;
        Image mg = obj.GetComponent<Image>();
        skillname = mg.sprite.name;
      
        SkillDefine skill = GameObject.Find("SkillManager").GetComponent<SkillDefine>();
        if(skillset=="1")
        {
            skill.SkiilStase1 = (Skill)int.Parse(skillname);
            Debug.Log(skillname);
        }
        if (skillset == "2")
        {
            skill.SkillStase2 = (Skill)int.Parse(skillname);
            Debug.Log(skillname);
        }
        if (skillset == "3")
        {
            skill.SkillStase3 = (Skill)int.Parse(skillname);
        }
        if (skillset == "4")
        {
            skill.SkillStase4 = (Skill)int.Parse(skillname);
        }


    }
}
