using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class BossController : MonoBehaviour
{
    [SerializeField] int stageNum;

    [SerializeField] GameObject bossObj;

    [SerializeField, Header("初期HP")] float defaultHp;
    float hp;
    float hpRatio = 1;

    [SerializeField, Header("HPバーの中身")] Image hpBar;
    [SerializeField, Header("BossのUI")] Animator bossUIAnim;
    [SerializeField, Header("HP減少時の減少スピード")] float decreaseSpeed;

    [SerializeField] Sprite[] hpBars;

    public float BossHp
    {
        get { return hp; }
        set { hp = value; }
    }

    bool screenInitialize = false; //弾全消去フラグ

    [SerializeField] WaveController waveController;
    [SerializeField] PlayableDirector director;
    int currentTrackIndex = 1;

    bool wave2 = false, wave3 = false, wave4 = false, end = false;

    [SerializeField, Header("ボス登場からボス戦WAVE１開始までの時間")] float entryTime;

    [SerializeField, Header("初期位置に戻るスピード")] float moveSpeed;
    [SerializeField, Header("各WAVE初期位置")] GameObject[] pos;
    bool isPosIni = false;

    [SerializeField, Header("各WAVE移行するときの残HP割合"), Tooltip("Element0が0.75の場合、残HPが75％以下でWAVE2に移行する")] float[] hpLimit; 

    [SerializeField] GameObject[] wave;

    //Stage1用
    [SerializeField, Header("ボスの分身")] GameObject[] bossClone;

    //Stage2用
    int wave4AttackCount = 1;

    public int BossWaveNum { get { return currentTrackIndex - 1; } }

    void Start()
    {
        hpBar.sprite = hpBars[0];
        hp = defaultHp;
        hpBar.fillAmount = 1;

        StartCoroutine(BossReach());

        wave[0].SetActive(true);
        wave[1].SetActive(false);
        wave[2].SetActive(false);
        wave[3].SetActive(false);

        if(stageNum == 1)
        {
            foreach (var b in bossClone)
            {
                b.SetActive(false);
            }
        }
    }

    void Update()
    {
        HpDirection();

        if (screenInitialize)
        {
            ScreenInitialize();
            screenInitialize = false;
        }

        //Debug
        if(Input.GetKeyDown(KeyCode.Space))
        {
            hp -= 200;
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            AnimationReplay();
        }

        //HPが一定以下になったら初期位置に戻る
        if (isPosIni)
        {
            director.Stop();
            TimelineAsset timelineAsset = director.playableAsset as TimelineAsset;
            director.ClearGenericBinding(timelineAsset.GetOutputTrack(currentTrackIndex));

            GameObject p;
            switch (currentTrackIndex)
            {
                case 1:
                    p = pos[0];
                    break;
                case 2:
                    p = pos[1];
                    break;
                case 3:
                    p = pos[2];
                    break;
                case 4:
                    p = pos[3];
                    break;
                case 5:
                    p = pos[3];
                    break;
                default:
                    p = pos[0];
                    break;
            }

            if(Vector3.Distance(bossObj.transform.localPosition, p.transform.localPosition) > 1)
            {
                Vector3 dir = (p.transform.localPosition - bossObj.transform.localPosition).normalized;

                Vector3 pos = bossObj.transform.localPosition;
                pos.x += dir.x;
                pos.y += dir.y;
                bossObj.transform.localPosition = pos;
            }

            else 
            {
                bossObj.transform.localPosition = p.transform.localPosition;
                SetBossBinding(); 
                isPosIni = false;

                if (stageNum == 1 && currentTrackIndex == 5)
                {
                    BossClone();
                }
            }
        }
    }

    //ボス戦移行
    IEnumerator BossReach()
    {
        //WAVEが全て終わったら
        yield return new WaitUntil(() => waveController.WaveCompleted);

        yield return new WaitForSeconds(3f);

        //登場
        TimelineAsset timelineAsset = director.playableAsset as TimelineAsset;
        director.SetGenericBinding(timelineAsset.GetOutputTrack(currentTrackIndex), bossObj);
        director.Stop();
        director.Play();

        yield return new WaitForSeconds(1f);

        //ボスのUI登場
        bossUIAnim.SetBool("Entry", true);

        //ここらへんにストーリー

        yield return new  WaitForSeconds(entryTime);

        SetBossBinding();
    }

    //HP関連
    void HpDirection()
    {
        hpRatio = hp / defaultHp;
        if(hpBar.fillAmount > hpRatio) { hpBar.fillAmount -= decreaseSpeed * Time.deltaTime; }
        else { hpBar.fillAmount = hpRatio; }

        if(hpRatio >= 2.0f / 3.0f) { hpBar.sprite = hpBars[0]; }
        else if (hpRatio >= 1.0f / 3.0f && hpRatio < 2.0f / 3.0f) { hpBar.sprite = hpBars[1]; }
        else if(hpRatio < 1.0f / 3.0f) { hpBar.sprite = hpBars[2]; }

        //残りHpに応じてWAVE変更
        if (hpRatio <= hpLimit[0] && !wave2)
        {
            wave2 = true;
            wave[1].SetActive(true);
            wave[0].SetActive(false);
            WaveChange(); 
        }
        else if (hpRatio <= hpLimit[1] && !wave3) 
        { 
            wave3 = true; 
            wave[2].SetActive(true);
            wave[1].SetActive(false); 
            WaveChange();
        }
        else if (hpRatio <= hpLimit[2] && !wave4) 
        { 
            wave4 = true;
            wave[3].SetActive(true);
            wave[2].SetActive(false);
            WaveChange(); 
        }
        else if (hp <= 0 && !end) 
        { 
            hp = 0; 
            end = true;
            wave[3].SetActive(false);
            WaveChange(); 
        }
    }

    //現在のWAVEが終了したら繰り返す Signalで呼び出し
    public void AnimationReplay()
    {
        if(currentTrackIndex <= 5)
        {
            director.Stop();
            director.Play();
        }
    }

    //WAVE移行
    void WaveChange()
    {
        isPosIni = true;
        screenInitialize = true;
    }

    //画面から弾を全削除 
    void ScreenInitialize()
    {
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullets");
        foreach (var b in bullets)
        {
            Destroy(b);
        }

        GameObject[] bigBullets = GameObject.FindGameObjectsWithTag("BigBullets");
        foreach (var b in bigBullets)
        {
            Destroy(b);
        }
    }

    //Timeline編集
    void SetBossBinding()
    {
        TimelineAsset timelineAsset = director.playableAsset as TimelineAsset;

        // 現在カメラが設定されているTrackのBindingをリセット
        director.ClearGenericBinding(timelineAsset.GetOutputTrack(currentTrackIndex));

        if(currentTrackIndex < 5)
        {
            currentTrackIndex++;
        }
        
        // 新しいTrackのBindingにカメラを設定
        director.SetGenericBinding(timelineAsset.GetOutputTrack(currentTrackIndex), bossObj);
        // CinemachineTrackの状態をリセット
        director.Stop();
        director.Play();
    }

    //Stage1 Boss Wave4 ボス分身
    void BossClone()
    {
        foreach (var b in bossClone)
        {
            b.SetActive(true);
        }

        TimelineAsset timelineAsset = director.playableAsset as TimelineAsset;

        for (int i = 0; i < bossClone.Length; i++)
        {
            director.SetGenericBinding(timelineAsset.GetOutputTrack(i + 6), bossClone[i]);
        }

        director.Stop();
        director.Play();
    }

    //Stage2 Boss Wave4 HP減少 Signalで呼び出し
    public void Stage2_Wave4()
    {
        if(currentTrackIndex == 5)
        {
            //if(wave4AttackCount == 5)
            //{
            //    hp = (defaultHp * 0.04f);
            //}
            //else { hp -= (defaultHp * 0.05f); }

            hp -= (defaultHp * 0.05f);

            wave4AttackCount++;
        }
    }
}
