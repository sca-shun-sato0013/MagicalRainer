using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Image HPGauge;
    [SerializeField] private Image SPGauge;
    [SerializeField] private Text SPText;
    [SerializeField] private int maxHP;
    private int hp;
    private int sp;

    [SerializeField] private int [] setSkills=new int[4];
    [SerializeField] private Image[] skills =new Image[6];


    // Start is called before the first frame update
    void Start()
    {
        hp = maxHP;
        sp = 0;
        for(int i = 0; i < 4; ++i)
        {
            Instantiate(skills[setSkills[i]],new Vector3(250+150*i, 450, 0),Quaternion.identity,transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        HPGauge.fillAmount = (float)hp / maxHP;
        SPText.text = sp / 10 + "/10";
        if (sp < 100)
        {
            SPGauge.fillAmount = (float)(sp % 10) / 10;
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                sp += 1;
            }
        }
        else
        {
            SPGauge.fillAmount = 1;
        }

        if (sp >= 40)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            skillOne();

            else if(Input.GetKeyDown(KeyCode.Alpha2))
            skillTow();

            else if(Input.GetKeyDown(KeyCode.Alpha3))
            skillThree();

            else if(Input.GetKeyDown(KeyCode.Alpha4))
            skillFour();
        }
    }

    void skillOne()
    {
        sp-=40;
    }

    void skillTow()
    {
        sp-=40;
    }

    void skillThree()
    {
        sp-=40;
    }

    void skillFour()
    {
        sp-=40;
    }
}
