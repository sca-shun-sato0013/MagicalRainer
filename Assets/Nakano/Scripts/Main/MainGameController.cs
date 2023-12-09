using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static PlayerManager;
using static TimeScoreCounter;

public class MainGameController : MonoBehaviour
{
    [SerializeField] int stageNum;
    enum Level {Easy, Normal, Hard, Galaxy};
    [SerializeField] Level level;

    [SerializeField] HorizonFade fade;
    [SerializeField] WaveController waveController;
    [SerializeField, Header("�Q�[���J�n���o")] Animator startDirection;

    [SerializeField, Header("WAVE�ڍs���o")] Animator waveDirection;
    [SerializeField] Text waveDirectionText;
    [SerializeField, Header("WAVE�Ԃ̃N�[���^�C��")] float coolTime;
    bool waveDirectionEnd = false;

    [SerializeField, Header("�Q�[���I�[�o�[/�N���A���o")] Animator endDirection;
    [SerializeField] Text endDirectionText;
    
    [SerializeField, Header("�w�i")] BackGround bg1, bg2;

    [SerializeField, Header("�^�C��")] Text timer;
    [SerializeField, Header("�X�R�A")] Text score;

    public bool WaveDirectionEnd
    {
        get { return waveDirectionEnd;}
    }

    IEnumerator GameStart()
    {
        timeCountState = TimeCountState.PAUSE;

        //�t�F�[�h���I�������
        yield return new WaitUntil(() => fade.FadeInEnd);

        //�Q�[���J�n�̃A�j���[�V�������Đ�
        startDirection.SetTrigger("Start");

        //�w�i�ړ�
        bg1.MoveTime = 3;
        bg1.MoveDistance = -351;
        bg2.MoveTime = 3;
        bg2.MoveDistance = -351;

        bg1.Move();
        bg2.Move();

        yield return new WaitUntil(() => startDirection.GetCurrentAnimatorStateInfo(0).IsName("StartDirection_End"));
        waveController.enabled = true;

        timeCountState = TimeCountState.COUNT;
    }
    
    void Start()
    {
        waveController.enabled = false;
        fade.FadeInStart();
        StartCoroutine(GameStart());
    }

    void Update()
    {
        if (game_stat == GameStat.DETH)
        {
            GameOverDirection();
        }

        timer.text = elapsedTime.ToString("f2");
    }

    /// <summary>
    /// WAVE�ڍs���o�Đ� bgScroll -> �w�i�̈ړ������邩�@WaveNumber -> ���Ԗڂ�WAVE��
    /// </summary>
    /// <param name="bgScroll"></param>
    /// <param name="WaveNumber"></param>
    public void WaveDirection(bool bgScroll, int WaveNumber)
    {
        timeCountState = TimeCountState.PAUSE;
        waveDirectionEnd = false;
        waveDirectionText.text = "WAVE" + (WaveNumber).ToString();

        //�uWAVE�v�̃e�L�X�g����ʓ���
        waveDirection.SetTrigger("In");

        StartCoroutine(WaveWait(bgScroll));

        //�v���C���[�̓������~�߂�
    }

    IEnumerator WaveWait(bool bgScroll)
    {
        //�uWAVE�v�̃e�L�X�g�������ɂ���܂ő҂�
        yield return new WaitUntil(() => waveDirection.GetCurrentAnimatorStateInfo(0).IsName("WaveDirection_Center"));

        //�w�i�ړ�
        if (waveController.WaveNum != 1 && bgScroll)
        {
            bg1.MoveTime = 2;
            bg1.MoveDistance = -70;
            bg2.MoveTime = 2;
            bg2.MoveDistance = -70;

            bg1.Move();
            bg2.Move();
        }
        
        //�N�[���^�C��
        yield return new WaitForSeconds(coolTime);

        //�uWAVE�v�̃e�L�X�g����ʊO��
        waveDirection.SetTrigger("Out");
        yield return new WaitForSeconds(1);

        //�G�ړ��J�n
        waveDirectionEnd = true;

        //�v���C���[�����ĊJ
        timeCountState = TimeCountState.COUNT;
    }

    public void GameClearDirection()
    {
        endDirectionText.text = "Game Clear";
        endDirection.SetTrigger("End");

        StartCoroutine(ToNextScene());
    }

    IEnumerator ToNextScene()
    {
        yield return new WaitForSeconds(3);

        fade.FadeOutStart();

        yield return new WaitUntil(() => fade.FadeOutEnd);

        switch (stageNum)
        {
            case 1:
                switch (level)
                {
                    case Level.Easy:
                        break;
                    case Level.Normal:
                        SceneManager.LoadScene("ResultScene");
                        //SceneManager.LoadScene("Stage2-Normal");
                        break;
                    case Level.Hard:
                        //SceneManager.LoadScene("Stage2-Hard");
                        break;
                    case Level.Galaxy:
                        break;
                }
                break;
            case 2:
                //���U���gWindow�\��
                break;
        }
    }

    void GameOverDirection()
    {
        timeCountState = TimeCountState.STOP;
        endDirectionText.text = "Game Over";
        endDirection.SetTrigger("End");

        StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1);
        //�Q�[���I�[�o�[Window�\��
    }
}
