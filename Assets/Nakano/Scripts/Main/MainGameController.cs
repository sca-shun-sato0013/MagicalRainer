using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainGameController : MonoBehaviour
{
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

    public bool WaveDirectionEnd
    {
        get { return waveDirectionEnd;}
    }

    IEnumerator GameStart()
    {
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

        //�uWAVE�v�̃e�L�X�g����ʓ���
        waveDirection.SetTrigger("In");

        StartCoroutine(WaveWait(bgScroll));
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
