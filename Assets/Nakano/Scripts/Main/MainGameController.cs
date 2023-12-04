using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainGameController : MonoBehaviour
{
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

    public bool WaveDirectionEnd
    {
        get { return waveDirectionEnd;}
    }

    IEnumerator GameStart()
    {
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
    }
    
    void Start()
    {
        waveController.enabled = false;
        fade.FadeInStart();
        StartCoroutine(GameStart());
    }

    void Update()
    {
    }

    public void WaveDirection(bool bgScroll, int WaveNumber)
    {
        waveDirectionEnd = false;
        waveDirectionText.text = "WAVE" + (WaveNumber).ToString();

        //「WAVE」のテキストを画面内へ
        waveDirection.SetTrigger("In");

        StartCoroutine(WaveWait(bgScroll));
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
    }

    public void GameClearDirection()
    {
        endDirectionText.text = "Game Clear";
        endDirection.SetTrigger("End");

        StartCoroutine(ToResult());
    }

    IEnumerator ToResult()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("ResultScene");
    }
}
