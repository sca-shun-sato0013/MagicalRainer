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
    public static int HP;
    private float tmpHP;
    private int SP;
    public static int skillGaugePoint;

    [SerializeField] private int [] setSkillsNumber=new int[4];
    [SerializeField] private Sprite[] skillSprite =new Sprite[6];
    [SerializeField] private Image[] setSkills=new Image[4];

    // Start is called before the first frame update
    void Start()
    {
        HP = maxHP;
        tmpHP=HP;
        SP = 0;
        skillGaugePoint = 0;
        for(int i = 0; i < 4; ++i)
        {
            setSkills[i].sprite = skillSprite[setSkillsNumber[i]];
        }
    }

    // Update is called once per frame
    void Update()
    {
        HPGauge.fillAmount = tmpHP / maxHP;
        SPText.text = SP + "/10";
        if (SP < 10)
        {
            if (SPGauge.fillAmount < (float)skillGaugePoint / 100)
            {
                SPGauge.fillAmount += Time.deltaTime;
            }
            if (SPGauge.fillAmount >= 1.0f)
            {
                skillGaugePoint -= 100;
                SPGauge.fillAmount = 0;
                SP += 1;
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

        if (tmpHP > HP)
        {
            tmpHP-=maxHP/10*Time.deltaTime;
        }
        else
        {
            tmpHP=HP;
        }

        if (SP >= 4)
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
        SP-=4;
    }

    void skillTow()
    {
        SP-=4;
    }

    void skillThree()
    {
        SP-=4;
    }

    void skillFour()
    {
        SP-=4;
    }
}
