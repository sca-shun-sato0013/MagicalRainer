using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class No1animetorStop : MonoBehaviour
{
    [SerializeField] GameObject Panel;
    [SerializeField] GameObject Panel2;

    private Animator anim;  //Animator��anim�Ƃ����ϐ��Œ�`����

    private void Start()
    {
        //�ϐ�anim�ɁAAnimator�R���|�[�l���g��ݒ肷��
       // anim = gameObject.GetComponent<Animator>();
    }

    IEnumerator Stop()
    {
        
        yield return new WaitForSeconds(3);
       // anim.SetBool("blRot", false);

        var isActive = Panel.activeInHierarchy; // Panel���A�N�e�B�u���擾
        Panel.SetActive(false);
        
        var isActivee = Panel2.activeInHierarchy; // Panel���A�N�e�B�u���擾
        Panel2.SetActive(true);

    }

    public void OnClick()
    {
       // anim.SetBool("blRot", true);
        StartCoroutine(Stop());
 


    }
}