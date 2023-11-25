using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class BossController : MonoBehaviour
{
    [SerializeField] GameObject bossObj;

    [SerializeField, Header("初期HP")] float defaultHp;
    float hp;
    float hpRatio = 1;

    [SerializeField, Header("HPバー")] Image hpBarFrame;
    [SerializeField, Header("HPバーの中身")] Image hpBar;
    [SerializeField, Header("ボスの名前")] Text bossName;

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
    [SerializeField, Header("各フェーズ初期位置")] Vector3[] pos;

    Vector3 nowPos;

    void Start()
    {
        hp = defaultHp;
        hpBar.fillAmount = 1;

        bossName.enabled = false;
        hpBar.enabled = false;
        hpBarFrame.enabled = false;

        StartCoroutine(BossReach());
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
            hp -= 10;
        }

        if(hp <= 0 && !end) { hp = 0; end = true; WaveChange(); }
    }

    IEnumerator BossReach()
    {
        //yield return new WaitUntil(() => waveController.WaveCompleted);

        yield return new WaitForSeconds(5f);

        bossName.enabled = true;
        hpBar.enabled = true;
        hpBarFrame.enabled = true;

        TimelineAsset timelineAsset = director.playableAsset as TimelineAsset;
        director.SetGenericBinding(timelineAsset.GetOutputTrack(currentTrackIndex), bossObj);
        director.Stop();
        director.Play();

        yield return new  WaitForSeconds(entryTime);

        SetBossBinding();
    }

    //HP演出
    void HpDirection()
    {
        hpRatio = hp / defaultHp;
        hpBar.fillAmount = hpRatio;

        //残りHpに応じてWAVE変更
        if (hpRatio <= 0.75f && !wave2) { wave2 = true; WaveChange(); nowPos = bossObj.transform.localPosition; }
        else if (hpRatio <= 0.5f && !wave3) { wave3 = true; WaveChange(); nowPos = bossObj.transform.localPosition; }
        else if (hpRatio <= 0.25f && !wave4) { wave4 = true; WaveChange(); nowPos = bossObj.transform.localPosition; }
    }

    public void AnimationReplay()
    {
        if(currentTrackIndex % 2 == 0 && currentTrackIndex < 9)
        {
            director.Play();
        }
    }

    public void WaitEnd()
    {
        if (currentTrackIndex % 2 == 1 && currentTrackIndex != 1)
        {
            SetBossBinding();
        }
    }

    public void Position()
    {
        StartCoroutine(PosInitialize());
    }

    IEnumerator PosInitialize()
    {
        Vector3 p;
        switch(currentTrackIndex)
        {
            case 3:
                p = pos[0];
                break;
            case 5:
                p = pos[1];
                break;
            case 7:
                p = pos[2];
                break;
            default:
                p = new Vector3(0,0,0);
                break;
        }

        if (currentTrackIndex % 2 == 1 && currentTrackIndex != 1)
        {
            director.Stop();
            while (Vector3.Distance(bossObj.transform.localPosition, p) >= 10)
            {
                Vector3 dir = (p - bossObj.transform.localPosition).normalized;
                bossObj.transform.Translate(dir * moveSpeed);
                yield return null;
            }

            SetBossBinding();
        }
    }

    void WaveChange()
    {
        //waveController.PlayNextWave();
        SetBossBinding();
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

    void SetBossBinding()
    {
        TimelineAsset timelineAsset = director.playableAsset as TimelineAsset;

        // 現在カメラが設定されているTrackのBindingをリセット
        director.ClearGenericBinding(timelineAsset.GetOutputTrack(currentTrackIndex));

        if(currentTrackIndex < 9)
        {
            currentTrackIndex++;
        }
        
        // 新しいTrackのBindingにカメラを設定
        director.SetGenericBinding(timelineAsset.GetOutputTrack(currentTrackIndex), bossObj);
        // CinemachineTrackの状態をリセット
        director.Stop();
        director.Play();
    }
}
