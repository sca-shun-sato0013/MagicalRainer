using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HelpBox : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private string _helpMessage;
    [SerializeField] private Text _text;

    [SerializeField] private string helpMessage;
   [SerializeField] private Text text;


    public void OnPointerEnter(PointerEventData eventData)
    {
      
        text.text = helpMessage;
        text.transform.gameObject.SetActive(true);

        _text.text = _helpMessage;
        _text.transform.gameObject.SetActive(true);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _text.transform.gameObject.SetActive(false);
        text.transform.gameObject.SetActive(false);
    }
}