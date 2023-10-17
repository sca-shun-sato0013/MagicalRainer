using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class No1animetorStop : MonoBehaviour
{
    [SerializeField] GameObject Panel;
    [SerializeField] GameObject Panel2;

    private Animator anim;  //Animatorをanimという変数で定義する

    private void Start()
    {
        //変数animに、Animatorコンポーネントを設定する
       // anim = gameObject.GetComponent<Animator>();
    }

    IEnumerator Stop()
    {
        
        yield return new WaitForSeconds(3);
       // anim.SetBool("blRot", false);

        var isActive = Panel.activeInHierarchy; // Panelがアクティブか取得
        Panel.SetActive(false);
        
        var isActivee = Panel2.activeInHierarchy; // Panelがアクティブか取得
        Panel2.SetActive(true);

    }

    public void OnClick()
    {
       // anim.SetBool("blRot", true);
        StartCoroutine(Stop());
 


    }
}