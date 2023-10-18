using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class No1animetorStop : MonoBehaviour
{
    [SerializeField] GameObject Panel;
    [SerializeField] GameObject Panel2;

    [SerializeField]
    private GameObject statusWindow;

    [SerializeField] Animator anim;

    //Animatorをanimという変数で定義する

    private void Start()
    {
        //変数animに、Animatorコンポーネントを設定する
        anim = gameObject.GetComponent<Animator>();
    }

    IEnumerator Stop()
    {
        GetComponent<Button>().interactable = false;

        yield return new WaitForSeconds(3);
       // anim.SetBool("blRot", false);

        var isActive = Panel.activeInHierarchy; // Panelがアクティブか取得
        Panel.SetActive(false);
        
        var isActivee = Panel2.activeInHierarchy; // Panelがアクティブか取得
        Panel2.SetActive(true);
        //GetComponent<Button>().interactable = false;
        //GetComponent<Button>().interactable = true;
        Cursor.lockState = CursorLockMode.None;
        Moveanim();


    }

    public void OnClick()
    {
        Cursor.lockState = CursorLockMode.Locked;
        anim.SetBool("blRot", true);
        StartCoroutine(Stop());

   
       // GetComponent<Button>().interactable = true;
        //anim.Play("idle");

    }

    private void Update()
    {
        
    }

    private void Moveanim()
    {
        if (statusWindow.activeSelf)
        {

        }
        else
        {
            GetComponent<Button>().interactable = true;
            anim.Play("idle");
        }
    }
}