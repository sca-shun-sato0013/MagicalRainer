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

    private float Bonus = 0.5f;
    private float totalScore;
    // Start is called before the first frame update
    void Start()
    {
        timeText.text ="" + GlobalVariables.AliveTime;
        TimeBonusText.text ="x" + Bonus;
        scoreText.text ="" +GlobalVariables.Score;
        hpText.text = "" + GlobalVariables.HP;
        TotalScore();
        TotalScoreText.text = "" + (int)totalScore;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void TotalScore()
    {
        totalScore = (GlobalVariables.AliveTime * 100) + (GlobalVariables.Score * Bonus) + GlobalVariables.HP;
    }
}
//���L
public static class GlobalVariables
{
    public static float AliveTime = 0; //��������
    public static int Score = 0; //�X�R�A
    public static int HP = 0; //HP
}
