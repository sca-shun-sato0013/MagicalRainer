using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillOK1 : MonoBehaviour
{
    private SkillFactory.SkillKind selectedSkillKind;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick()
    {
      SkillFactory skok = GetComponent<SkillFactory>();
        skok.SkillSetOK();

    }
}
