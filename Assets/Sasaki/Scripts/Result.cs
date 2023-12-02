using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField, Header("生存タイム")] private Text timeText;
    [SerializeField, Header("生存タイムのpos")] private RectTransform rectTimeText;
    [SerializeField, Header("タイムボーナス")] private Text TimeBonusText;
    [SerializeField,Header("スコア")] private Text scoreText;
    [SerializeField, Header("HP")] private Text hpText;
    [SerializeField, Header("トータススコア")] private Text TotalScoreText;

    private float bonus;
    private float totalScore;
    float hours;
    float minutes;
    float seconds;
    //float comma = 0f;
    float t;
    bool timeCheck = false;

    //TextMove
    [SerializeField, Header("テキストオブジェクト表示の順番")] private GameObject[] totalObjects;
    [SerializeField, Header("表示時間")] private float time = 1.0f;
    float resetTime;

    int textCount = 1;
    bool tCheck = false;

    //BadgesImage
    [SerializeField, Header("バッジ表示")] private GameObject[] imaBadges;

    void Start()
    {
        t = 0.0f;
        Timer();
        BonusScore();
        scoreText.text ="" + GlobalVariables.Score;
        hpText.text = "" + GlobalVariables.HP;
        TotalScore();
        TotalScoreText.text = "" + (int)totalScore + " pt";
        resetTime = time;
    }

    private void Update()
    {

        if (t <= GlobalVariables.AliveTime)
        {
            Timer();
            TimeMoveText();
            t++;
            if (Input.GetKeyDown(KeyCode.Return))
            {
                t = GlobalVariables.AliveTime;
                Timer();
                textCount += 1;
            }
            //表示
            //timeText.text = ($"{minutes.ToString("00")}:{seconds.ToString("00")}:{comma.ToString("00")}");
            timeText.text = ($"{hours.ToString("00")}:{minutes.ToString("00")}:{seconds.ToString("00")}");
        }
        if (t == GlobalVariables.AliveTime)
        {
            MoveText();
        }
        switch (textCount)
        {
            case 1:
                Timer();
                break;
            case 2:
                time -= Time.deltaTime;
                MoveText();
                break;
            default:
                t = GlobalVariables.AliveTime;
                Timer();
                break;
        }
    }
    //切り捨て
    void Timer()
    {
        //comma = GlobalVariables.AliveTime;
        //comma = (comma - Mathf.Floor(comma)) * 100;
        //comma = Mathf.Floor(comma);
        seconds = t;
        seconds = Mathf.Floor(seconds);

        minutes = seconds / 60;
        minutes = Mathf.Floor(minutes);

        hours = minutes / 60;
        hours = Mathf.Floor(hours);

        seconds -= minutes * 60;
        minutes -= hours * 60;
    }
    //ボーナススコア計算
    void BonusScore()
    {
        float s;
        s = GlobalVariables.AliveTime;
        s = Mathf.Floor(s);

        float m;
        m = s / 60;
        m = Mathf.Floor(m);

        float b =m;

        if (b >= 30)
        {
            bonus = 1.0f;
        }
        if (b < 30 && b >= 20)
        {
            bonus = 1.1f;
        }
        if (b < 20 && b >= 15)
        {
            bonus = 1.2f;
        }
        if (b < 15 && b >= 10)
        {
            bonus = 1.3f;
        }
        if (b < 10 && b >= 5)
        {
            bonus = 1.4f;
        }
        if (b < 5 && b >= 0)
        {
            bonus = 1.5f;
        }
        TimeBonusText.text = "×" + bonus.ToString("f1");
    }
    //トータルスコア計算
    void TotalScore()
    {
        float s;
        s = GlobalVariables.AliveTime;
        s = Mathf.Floor(s);

        const int clearScore = 360000;
        //totalScore = ((minutes * 60 + seconds) + comma / 100)* 100 * bonus + GlobalVariables.Score + GlobalVariables.HP;
        totalScore = (clearScore - (s * 10)) * bonus + ( GlobalVariables.Score + GlobalVariables.HP);
    }
    //タイム横揺れのアニメーション
    void TimeMoveText()
    {
        //if (this.rectTimeText.position.x >= 1f)
        //{
        //    this.rectTimeText.position += new Vector3(this.rectTimeText.position.x - 1, 0, 0);
        //}
        //if (this.rectTimeText.position.x <= 1f)
        //{
        //    this.rectTimeText.position += new Vector3(this.rectTimeText.position.x + 1, 0, 0);
        //}
    }
    //テキストを順番に表示
    void MoveText()
    {
        bool c = false;
        time -= Time.deltaTime;

        if (time <= 0)
        {
            for (int count = 0; count < 4; count++)
            {
                totalObjects[count].SetActive(true);
                time = 1;
            }
            c = true;
        }
        if (c)
        {
            BadgesImage();
        }
    }
    //総合評価
    void BadgesImage()
    {
        if (totalScore < 200000)
        {
            imaBadges[0].gameObject.SetActive(true);
        }
        else if (totalScore < 300000 && totalScore >= 200000)
        {
            imaBadges[1].gameObject.SetActive(true);
        }
        else if (totalScore < 500000 && totalScore >= 300000)
        {
            imaBadges[2].gameObject.SetActive(true);
        }
        else if (totalScore < 750000 && totalScore >= 500000)
        {
            imaBadges[3].gameObject.SetActive(true);
        }
        else if (totalScore < 1000000 && totalScore >= 750000)
        {
            imaBadges[4].gameObject.SetActive(true);
        }
        else if (totalScore >= 1000000)
        {
            imaBadges[5].gameObject.SetActive(true);
        }
    }
}
