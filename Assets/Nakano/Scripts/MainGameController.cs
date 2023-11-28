using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameController : MonoBehaviour
{
    [SerializeField] HorizonFade fade;
    [SerializeField] WaveController waveController;
    [SerializeField, Header("�Q�[���J�n���o")] GameObject startDirection;

    [SerializeField] Animator waveDirection;
    [SerializeField] Text waveDirectionText;

    IEnumerator GameStart()
    {
        yield return new WaitUntil(() => fade.FadeInEnd);

        Animator dir = startDirection.GetComponent<Animator>();
        dir.SetBool("Start", true);

        StartDirection s = startDirection.GetComponent<StartDirection>();
        yield return new WaitUntil(() => s.IsDirectionEnd);

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

    public void WaveDirection()
    {
        waveDirectionText.text = "WAVE" + (waveController.WaveNum).ToString();
        waveDirection.SetTrigger("In");

        //�w�i�X�N���[�����I�������

        waveDirection.SetTrigger("Out");
    }
}
