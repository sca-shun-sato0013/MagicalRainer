using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  enum Skill
{
    _None,
    Stargazer,
    Pentagram,
    Energyfunnel,
    Mysticfield,
    Skill5,
    Skill6,
}
public class SkillDefine : MonoBehaviour
{
    
   public static Skill skillSet1;
  
    public static Skill skillSet2;
   
    public static Skill skillSet3;
   
    public static Skill  skillSet4;

    public Skill SkiilStase1
    {
        set { skillSet1 = value; }
    }
    public Skill SkillStase2
    {
        set { skillSet2 = value; }
    }
    public Skill SkillStase3
    {
        set { skillSet3 = value; }
    }
    public Skill SkillStase4
    {
        set { skillSet4 = value; }
    }
   

    public static Dictionary<Skill, string> dic_SkillName = new Dictionary<Skill, string>()
    {
        {Skill._None, "スキル無し"},
        {Skill. Stargazer, "スターゲイザー"},
        {Skill.Pentagram, "ペンタグラム"},
        {Skill.Energyfunnel, "エネルギーファンネル"},
        {Skill.Mysticfield, "ミスティックフィールド"},
        {Skill.Skill5, "スキル5"},
        {Skill.Skill6, "スキル6"},
    };
    // Start is called before the first frame update
    void Start()
    {
        Skill skill= Skill._None;
        Debug.Log(skill);
        skillSet1 = Skill._None;
    }

    void SkillChange()
    {

    }
    // Update is called once per frame
    void Update()
    {
        SkillChange();
    }
 
}
