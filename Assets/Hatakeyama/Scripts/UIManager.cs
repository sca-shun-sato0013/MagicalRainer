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
    public static int skillGaugePoint;

    [SerializeField] private int [] setSkillsNumber=new int[4];
    [SerializeField] private Sprite[] skillSprite =new Sprite[6];
    [SerializeField] private Image[] setSkills=new Image[4];

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHP;
        sp = 0;
        skillGaugePoint = 0;
        for(int i = 0; i < 4; ++i)
        {
            setSkills[i].sprite = skillSprite[setSkillsNumber[i]];
        }
    }

    // Update is called once per frame
    void Update()
    {
        HPGauge.fillAmount = (float)hp / maxHP;
        //sp = (int)(skillGaugePoint / 100.0f);
        SPText.text = sp + "/10";
        if (sp < 10)
        {
            if (SPGauge.fillAmount < (float)skillGaugePoint / 100)
            {
                SPGauge.fillAmount += 0.01f;
            }
            if (SPGauge.fillAmount >= 1.0f)
            {
                skillGaugePoint = 0;
                SPGauge.fillAmount = 0;
                sp += 1;
            }
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                skillGaugePoint += 10;
            }
        }
        else
        {
            SPGauge.fillAmount = 1;
        }

        if (sp >= 4)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            skillOne();

            else if(Input.GetKeyDown(KeyCode.Alpha2))
            skillTow();

            else if(Input.GetKeyDown(KeyCode.Alpha3))
            skillThree();

            else if(Input.GetKeyDown(KeyCode.Alpha4))
            skillFour();

            for(int i = 0; i < setSkillsNumber.Length; ++i)
            {
                setSkills[setSkillsNumber[i]].color=new Color(1,1,1);
            }
        }
        else
        {
            for (int i = 0; i < setSkillsNumber.Length; ++i)
            {
                setSkills[i].color = new Color(0.5f, 0.5f, 0.5f);
            }
        }
    }

    void skillOne()
    {
        sp-=4;
    }

    void skillTow()
    {
        sp-=4;
    }

    void skillThree()
    {
        sp-=4;
    }

    void skillFour()
    {
        sp-=4;
    }
}
