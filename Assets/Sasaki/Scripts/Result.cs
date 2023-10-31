using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField, Header("�����^�C��")] private Text timeText;
    [SerializeField, Header("�^�C���{�[�i�X")] private Text TimeBonusText;
    [SerializeField,Header("�X�R�A")] private Text scoreText;
    [SerializeField, Header("HP")] private Text hpText;
    [SerializeField, Header("�g�[�^�X�X�R�A")] private Text TotalScoreText;

    private float Bonus = 1.5f;
    private float totalScore;
    int minutes = 0;
    float seconds = 0f;
    float comma = 0;
    // Start is called before the first frame update
    void Start()
    {
        Timer();
        TimeBonusText.text ="x" + Bonus;
        scoreText.text ="" + GlobalVariables.Score;
        hpText.text = "" + GlobalVariables.HP;
        TotalScore();
        TotalScoreText.text = "" + (int)totalScore;
    }

    // Update is called once per frame
    void Update()
    {
        //�\��
        timeText.text = ($"{minutes.ToString("00")}:{seconds.ToString("00")}:{comma.ToString("00")}");
        
    }

    //�؂�̂�
    void Timer()
    {
        comma = GlobalVariables.AliveTime;
        comma = (comma - Mathf.Floor(comma)) * 100;
        comma = Mathf.Floor(comma);

        seconds = GlobalVariables.AliveTime;
        seconds = Mathf.Floor(seconds);
        if (GlobalVariables.AliveTime >= 60f)
        {
            minutes++;
            seconds -= 60f;
        }
    }
    void TotalScore()
    {
        totalScore = (GlobalVariables.AliveTime * 100) + (GlobalVariables.Score * Bonus) + GlobalVariables.HP;
    }
}
//���L
public static class GlobalVariables
{
    public static float AliveTime = 65f; //��������
    public static int Score = 0; //�X�R�A
    public static int HP = 0; //HP
}
