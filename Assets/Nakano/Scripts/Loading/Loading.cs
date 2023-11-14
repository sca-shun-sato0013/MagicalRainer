using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    [SerializeField] GameObject LoadingUI;

    AsyncOperation async;
    bool isLoad = false;

    [Header("��l��")]
    [SerializeField] GameObject Character;
    [SerializeField] float charaSpeed;
    [SerializeField] float charaPosX;
    bool isCharaMove = false;
    [SerializeField] Animator charaAnim;

    [Header("�G")]
    [SerializeField] GameObject Enemy;
    [SerializeField] float enemySpeed;
    [SerializeField] float enemyPosX;

    [SerializeField] GameObject bg1, bg2;

    [Header("�t�F�[�h")]
    [SerializeField, Header("�N���X�t�F�[�h�̑��x")] float crossFadeSpeed;
    [SerializeField] GameObject fadeOut;
    HorizonFade fade;

    CanvasGroup loadingWindow;
    [SerializeField, Header("�J�ڑO�ɕ\�����Ă���Canvas")] CanvasGroup lastWindow;

    void Start()
    {
        LoadingUI.SetActive(false);
        fade = fadeOut.GetComponent<HorizonFade>();

        loadingWindow = LoadingUI.GetComponent<CanvasGroup>();
    }

    private void FixedUpdate()
    {
        if(isLoad)
        {
            LoadComplete();
        }
    }

    public void LoadNextScene()
    {
        LoadingUI.SetActive(true);
        StartCoroutine(CrossFade());
        StartCoroutine(LoadScene());
    }

    IEnumerator CrossFade()
    {
        while(loadingWindow.alpha <= 1)
        {
            loadingWindow.alpha += crossFadeSpeed;
            lastWindow.alpha -= crossFadeSpeed;
            yield return null;
        }
    }

    IEnumerator LoadScene()
    {
        async = SceneManager.LoadSceneAsync("BulletScene");
        async.allowSceneActivation = false;

        while (async.progress < 0.9f)
        {
            yield return null;
        }

        if(async.progress >= 0.9f)
        {
            //���[�h����
            isLoad = true;
        }
    }

    void LoadComplete()
    {
        //�G�ړ�
        if(Enemy.transform.position.x > enemyPosX)
        {
            Enemy.transform.Translate(enemySpeed * Time.deltaTime, 0, 0);
        }

        if(Enemy.transform.position.x <= enemyPosX)
        {
            //�w�i�X�N���[����~
            bg1.GetComponent<BG>().IsMove = false;
            bg2.GetComponent<BG>().IsMove = false;
            isCharaMove = true;
        }

        if(isCharaMove)
        {
            if (Character.transform.position.x < charaPosX)
            {
                Character.transform.Translate(charaSpeed * Time.deltaTime, 0, 0);
            }

            if (Character.transform.position.x >= charaPosX)
            {
                charaAnim.SetBool("Stop", true);
                //�t�F�[�h����
                fade.FadeOutStart();

                if(fade.FadeOutEnd)
                {
                    async.allowSceneActivation = true;
                }
            }
        }
    }
}
