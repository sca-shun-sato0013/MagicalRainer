using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPattern;

public class SkillData : Singleton<SkillData>
{
    string[] selectSkillData = new string[4];

    public string[] SelectSkillData
    { 
        get { return selectSkillData; }
        set { selectSkillData = value; }
    }
}
