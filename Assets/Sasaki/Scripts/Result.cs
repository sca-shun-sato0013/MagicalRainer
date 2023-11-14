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
    float minutes = 0f;
    float seconds = 0f;
    float comma = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Timer();
        bonus = 1.0f;
        BonusScore();
        TimeBonusText.text = "×" + bonus.ToString("f1");
        scoreText.text ="" + GlobalVariables.Score;
        hpText.text = "" + GlobalVariables.HP;
        TotalScore();
        TotalScoreText.text = "" + (int)totalScore;
    }

    //切り捨て
    void Timer()
    {
        comma = GlobalVariables.AliveTime;
        comma = (comma - Mathf.Floor(comma)) * 100;
        comma = Mathf.Floor(comma);

        seconds = GlobalVariables.AliveTime;
        seconds = Mathf.Floor(seconds);

        minutes = seconds / 60;
        minutes = Mathf.Floor(minutes);

        seconds -= minutes * 60;

        //表示
        timeText.text = ($"{minutes.ToString("00")}:{seconds.ToString("00")}:{comma.ToString("00")}");
    }
    void BonusScore()
    {
        float BS = GlobalVariables.AliveTime / 60;
        BS = Mathf.Floor(BS);
        bonus = BS / 10 + 1;
    }
    void TotalScore()
    {
        totalScore = ((minutes * 60 + seconds) + comma / 100)* 100 * bonus + GlobalVariables.Score + GlobalVariables.HP;
    }
}
