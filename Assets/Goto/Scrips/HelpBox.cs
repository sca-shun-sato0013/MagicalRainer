using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections;

public class HelpBox : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private string _helpMessage;
    [SerializeField] private Text _text;

    [SerializeField] private string helpMessage;
   [SerializeField] private Text text;

    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] GameObject Panel;


    public void OnPointerEnter(PointerEventData eventData)
    {
      
        text.text = helpMessage;
        text.transform.gameObject.SetActive(true); //スキル名表示

        _text.text = _helpMessage;
        _text.transform.gameObject.SetActive(true);　//スキル説明

        Panel.SetActive(true); //videoPlayerのパネル表示
        StartCoroutine(Start());
       
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _text.transform.gameObject.SetActive(false); //テキスト消す
        text.transform.gameObject.SetActive(false);　//テキスト消す

        videoPlayer.Stop();
        Panel.SetActive(false);　//videoplayerのパネル非表示
       // StartCoroutine(Stop());

    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);
        videoPlayer.Play();
    }

    //IEnumerator Stop()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    Panel.SetActive(false);
    //}
}