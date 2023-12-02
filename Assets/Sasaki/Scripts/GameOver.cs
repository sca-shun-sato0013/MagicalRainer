using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField, Header("�����^�C��")] private Text timeText;
    [SerializeField, Header("�����^�C����pos")] private RectTransform rectTimeText;
    [SerializeField, Header("�X�R�A")] private Text scoreText;
    [SerializeField, Header("HP")] private Text hpText;
    [SerializeField, Header("�g�[�^�X�X�R�A")] private Text TotalScoreText;

    private float totalScore;
    float hours;
    float minutes;
    float seconds;
    //float comma = 0f;
    float t;
    bool timeCheck = false;

    //TextMove
    [SerializeField, Header("�e�L�X�g�I�u�W�F�N�g�\���̏���")] private GameObject[] totalObjects;
    [SerializeField, Header("�\������")] private float time = 1.0f;
    float resetTime;

    int textCount = 0;
    bool tCheck = false;

    //BadgesImage
    [SerializeField, Header("�o�b�W�\��")] private GameObject[] imaBadges;

    void Start()
    {
        t = 0.0f;
        Timer();
        scoreText.text = "" + GlobalVariables.Score;
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
            //�\��
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
                MoveText();
                break;
            default:
                Timer();
                break;
        }
    }
    //�؂�̂�
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
    //�g�[�^���X�R�A�v�Z
    void TotalScore()
    {
        float s;
        s = GlobalVariables.AliveTime;
        s = Mathf.Floor(s);

        const int clearScore = 360000;
        //totalScore = ((minutes * 60 + seconds) + comma / 100)* 100 * bonus + GlobalVariables.Score + GlobalVariables.HP;
        totalScore = (clearScore - (s * 10)) + (GlobalVariables.Score + GlobalVariables.HP);
    }
    //�^�C�����h��̃A�j���[�V����
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
    //�e�L�X�g�����Ԃɕ\��
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
    //�����]��
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
