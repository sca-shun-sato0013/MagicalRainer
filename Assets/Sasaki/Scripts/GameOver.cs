using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField, Header("�����^�C��")] private Text timeText;
    [SerializeField, Header("�X�R�A")] private Text scoreText;
    [SerializeField, Header("HP")] private Text hpText;
    [SerializeField, Header("�g�[�^�X�X�R�A")] private Text TotalScoreText;

    private float totalScore;
    float minutes = 0f;
    float seconds = 0f;
    float comma = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Timer();
        scoreText.text = "" + GlobalVariables.Score;
        hpText.text = "" + GlobalVariables.HP;
        TotalScore();
        TotalScoreText.text = "" + (int)totalScore;
    }

    //�؂�̂�
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

        //�\��
        timeText.text = ($"{minutes.ToString("00")}:{seconds.ToString("00")}:{comma.ToString("00")}");
    }
    void TotalScore()
    {
        totalScore = ((minutes * 60 + seconds) + comma / 100) * 100 + GlobalVariables.Score + GlobalVariables.HP;
    }
}
