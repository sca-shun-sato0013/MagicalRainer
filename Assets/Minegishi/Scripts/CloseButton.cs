using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseButton : MonoBehaviour
{
    [SerializeField] GameObject canvas;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnClick()
    {
        Debug.Log("����");
        canvas.SetActive(false);
        //SceneManager.LoadScene("testScene");
    }
}
