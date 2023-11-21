using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField, Header("生存タイム")] private Text timeText;
    [SerializeField, Header("スコア")] private Text scoreText;
    [SerializeField, Header("HP")] private Text hpText;
    [SerializeField, Header("トータススコア")] private Text TotalScoreText;

    private float totalScore;
    float hours = 0f;
    float minutes = 0f;
    float seconds = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Timer();
        scoreText.text = "" + GlobalVariables.Score;
        hpText.text = "" + GlobalVariables.HP;
        TotalScore();
        TotalScoreText.text = "" + (int)totalScore;
    }

    //切り捨て
    void Timer()
    {
        seconds = GlobalVariables.AliveTime;
        seconds = Mathf.Floor(seconds);

        minutes = seconds / 60;
        minutes = Mathf.Floor(minutes);

        hours = minutes / 60;
        hours = Mathf.Floor(hours);

        seconds -= minutes * 60;
        minutes -= hours * 60;

        timeText.text = ($"{hours.ToString("00")}:{minutes.ToString("00")}:{seconds.ToString("00")}");
    }
    void TotalScore()
    {
        const int clearScore = 360000;
        totalScore = (clearScore - (((hours * 60 * 60) + minutes * 60 + seconds)) * 10) + (GlobalVariables.Score + GlobalVariables.HP);
    }
}
