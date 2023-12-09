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
    [SerializeField, Header("ゲーム開始演出")] Animator startDirection;

    [SerializeField, Header("WAVE移行演出")] Animator waveDirection;
    [SerializeField] Text waveDirectionText;
    [SerializeField, Header("WAVE間のクールタイム")] float coolTime;
    bool waveDirectionEnd = false;

    [SerializeField, Header("ゲームオーバー/クリア演出")] Animator endDirection;
    [SerializeField] Text endDirectionText;
    
    [SerializeField, Header("背景")] BackGround bg1, bg2;

    [SerializeField, Header("タイム")] Text timer;
    [SerializeField, Header("スコア")] Text score;

    public bool WaveDirectionEnd
    {
        get { return waveDirectionEnd;}
    }

    IEnumerator GameStart()
    {
        timeCountState = TimeCountState.PAUSE;

        //フェードが終わったら
        yield return new WaitUntil(() => fade.FadeInEnd);

        //ゲーム開始のアニメーションを再生
        startDirection.SetTrigger("Start");

        //背景移動
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
    /// WAVE移行演出再生 bgScroll -> 背景の移動をするか　WaveNumber -> 何番目のWAVEか
    /// </summary>
    /// <param name="bgScroll"></param>
    /// <param name="WaveNumber"></param>
    public void WaveDirection(bool bgScroll, int WaveNumber)
    {
        timeCountState = TimeCountState.PAUSE;
        waveDirectionEnd = false;
        waveDirectionText.text = "WAVE" + (WaveNumber).ToString();

        //「WAVE」のテキストを画面内へ
        waveDirection.SetTrigger("In");

        StartCoroutine(WaveWait(bgScroll));

        //プレイヤーの動きを止める
    }

    IEnumerator WaveWait(bool bgScroll)
    {
        //「WAVE」のテキストが中央にくるまで待つ
        yield return new WaitUntil(() => waveDirection.GetCurrentAnimatorStateInfo(0).IsName("WaveDirection_Center"));

        //背景移動
        if (waveController.WaveNum != 1 && bgScroll)
        {
            bg1.MoveTime = 2;
            bg1.MoveDistance = -70;
            bg2.MoveTime = 2;
            bg2.MoveDistance = -70;

            bg1.Move();
            bg2.Move();
        }
        
        //クールタイム
        yield return new WaitForSeconds(coolTime);

        //「WAVE」のテキストを画面外へ
        waveDirection.SetTrigger("Out");
        yield return new WaitForSeconds(1);

        //敵移動開始
        waveDirectionEnd = true;

        //プレイヤー挙動再開
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
                //リザルトWindow表示
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
        //ゲームオーバーWindow表示
    }
}
