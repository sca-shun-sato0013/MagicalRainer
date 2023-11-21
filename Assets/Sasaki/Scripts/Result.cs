using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField, Header("生存タイム")] private Text timeText;
    [SerializeField, Header("タイムボーナス")] private Text TimeBonusText;
    [SerializeField,Header("スコア")] private Text scoreText;
    [SerializeField, Header("HP")] private Text hpText;
    [SerializeField, Header("トータススコア")] private Text TotalScoreText;

    private float bonus;
    private float totalScore;
    float hours = 0f;
    float minutes = 0f;
    float seconds = 0f;
    //float comma = 0f;
    float t;

    //TextMove
    [SerializeField, Header("表示の順番")] private GameObject[] totalObjects;
    [SerializeField, Header("表示時間")] private float time = 1.0f;
    float resetTime;
    int count = -1;

    bool tCheck = false;
    // Start is called before the first frame update
    void Start()
    {
        t = 0.0f;
        Timer();
        BonusScore();
        TimeBonusText.text = "×" + bonus.ToString("f1");
        scoreText.text ="" + GlobalVariables.Score;
        hpText.text = "" + GlobalVariables.HP;
        TotalScore();
        TotalScoreText.text = "" + (int)totalScore + " pt";
        resetTime = time;

    }
    private void Update()
    {
        if (t < GlobalVariables.AliveTime)
        {
            Timer();
            t++;

            if (Input.GetKeyDown(KeyCode.Return))
            {
                tCheck = true;
                t = GlobalVariables.AliveTime;
                Timer();
            }
            //表示
            //timeText.text = ($"{minutes.ToString("00")}:{seconds.ToString("00")}:{comma.ToString("00")}");
            timeText.text = ($"{hours.ToString("00")}:{minutes.ToString("00")}:{seconds.ToString("00")}");
            tCheck = true;
        }
        if (tCheck)
        {
            time -= Time.deltaTime;
            MoveText();
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
    void BonusScore()
    {
        float t = hours * 60 + minutes;

        if (t >= 30)
        {
            bonus = 1.0f;
        }
        if (t < 30 && t >= 20)
        {
            bonus = 1.1f;
        }
        if (t < 20 && t >= 15)
        {
            bonus = 1.2f;
        }
        if (t < 15 && t >= 10)
        {
            bonus = 1.3f;
        }
        if (t < 10 && t >= 5)
        {
            bonus = 1.4f;
        }
        if (t < 5 && t >= 0)
        {
            bonus = 1.5f;
        }

    }
    void TotalScore()
    {
        const int clearScore = 360000; 
        //totalScore = ((minutes * 60 + seconds) + comma / 100)* 100 * bonus + GlobalVariables.Score + GlobalVariables.HP;
        totalScore = (clearScore - (((hours * 60 * 60) +  minutes * 60 + seconds)) * 10) * bonus + ( GlobalVariables.Score + GlobalVariables.HP);
    }
    void MoveText()
    {
        if (time <= 0)
        {
            //for (int count = 0; count > 4; count++)
            //{
            //    totalObjects[count].SetActive(true);
            //    time = resetTime;
            //    break;
            //}
        }
    }
}
