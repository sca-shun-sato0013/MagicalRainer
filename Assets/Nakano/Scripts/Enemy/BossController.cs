using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class BossController : MonoBehaviour
{
    [SerializeField] GameObject bossObj;

    [SerializeField, Header("����HP")] float defaultHp;
    float hp;
    float hpRatio = 1;

    [SerializeField, Header("HP�o�[�̒��g")] Image hpBar;
    [SerializeField, Header("Boss��UI")] Animator bossUIAnim;

    public float BossHp
    {
        get { return hp; }
        set { hp = value; }
    }

    bool screenInitialize = false; //�e�S�����t���O

    [SerializeField] WaveController waveController;
    [SerializeField] PlayableDirector director;
    int currentTrackIndex = 1;

    bool wave2 = false, wave3 = false, wave4 = false, end = false;

    [SerializeField, Header("�{�X�o�ꂩ��{�X��WAVE�P�J�n�܂ł̎���")] float entryTime;

    [SerializeField, Header("�����ʒu�ɖ߂�X�s�[�h")] float moveSpeed;
    [SerializeField, Header("�e�t�F�[�Y�����ʒu")] GameObject[] pos;
    bool isPosIni = false;

    [SerializeField] GameObject[] wave;

    int wave4AttackCount = 1;
 
    void Start()
    {
        hp = defaultHp;
        hpBar.fillAmount = 1;

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

        if(Input.GetKeyDown(KeyCode.V))
        {
            Time.timeScale = 0;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Time.timeScale = 1;
        }

        //HP�����ȉ��ɂȂ����珉���ʒu�ɖ߂�
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

            else { bossObj.transform.localPosition = p.transform.localPosition; SetBossBinding(); isPosIni = false; }
        }
    }

    IEnumerator BossReach()
    {
        //yield return new WaitUntil(() => waveController.WaveCompleted);

        yield return new WaitForSeconds(5f);

        TimelineAsset timelineAsset = director.playableAsset as TimelineAsset;
        director.SetGenericBinding(timelineAsset.GetOutputTrack(currentTrackIndex), bossObj);
        director.Stop();
        director.Play();

        yield return new WaitForSeconds(1f);

        bossUIAnim.SetBool("Entry", true);

        //������ւ�ɃX�g�[���[

        yield return new  WaitForSeconds(entryTime);

        SetBossBinding();
    }

    //HP���o
    void HpDirection()
    {
        hpRatio = hp / defaultHp;
        hpBar.fillAmount = hpRatio;

        //�c��Hp�ɉ�����WAVE�ύX
        if (hpRatio <= 0.75f && !wave2) { wave2 = true; WaveChange(); wave[0].SetActive(false); }
        else if (hpRatio <= 0.5f && !wave3) { wave3 = true; WaveChange(); wave[1].SetActive(false); }
        else if (hpRatio <= 0.25f && !wave4) { wave4 = true; WaveChange(); wave[2].SetActive(false); }
        else if (hp <= 0 && !end) { hp = 0; end = true; WaveChange(); wave[3].SetActive(false); }
    }

    //���݂�WAVE���I��������J��Ԃ� Signal�ŌĂяo��
    public void AnimationReplay()
    {
        if(currentTrackIndex <= 5)
        {
            director.Play();
        }
    }

    //WAVE�ڍs
    void WaveChange()
    {
        isPosIni = true;
        screenInitialize = true;
    }

    //��ʂ���e��S�폜 
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

    //Timeline�ҏW
    void SetBossBinding()
    {
        TimelineAsset timelineAsset = director.playableAsset as TimelineAsset;

        // ���݃J�������ݒ肳��Ă���Track��Binding�����Z�b�g
        director.ClearGenericBinding(timelineAsset.GetOutputTrack(currentTrackIndex));

        if(currentTrackIndex < 5)
        {
            currentTrackIndex++;
        }
        
        // �V����Track��Binding�ɃJ������ݒ�
        director.SetGenericBinding(timelineAsset.GetOutputTrack(currentTrackIndex), bossObj);
        // CinemachineTrack�̏�Ԃ����Z�b�g
        director.Stop();
        director.Play();
    }

    //Stage2 Boss Wave4 HP���� Signal�ŌĂяo��
    public void Stage2_Wave4()
    {
        if(currentTrackIndex == 5)
        {
            if(wave4AttackCount == 5)
            {
                hp -= (defaultHp * 0.04f);
            }
            else { hp -= (defaultHp * 0.05f); }
            wave4AttackCount++;
        }
    }
}
