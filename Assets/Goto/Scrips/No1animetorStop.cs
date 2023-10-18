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

    //Animator��anim�Ƃ����ϐ��Œ�`����

    private void Start()
    {
        //�ϐ�anim�ɁAAnimator�R���|�[�l���g��ݒ肷��
        anim = gameObject.GetComponent<Animator>();
    }

    IEnumerator Stop()
    {
        GetComponent<Button>().interactable = false;

        yield return new WaitForSeconds(3);
       // anim.SetBool("blRot", false);

        var isActive = Panel.activeInHierarchy; // Panel���A�N�e�B�u���擾
        Panel.SetActive(false);
        
        var isActivee = Panel2.activeInHierarchy; // Panel���A�N�e�B�u���擾
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