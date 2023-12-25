using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundSetting : MonoBehaviour
{
    [SerializeField] GameObject canvas;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        
    }

    public void OnClick()
    {
        Debug.Log("•Â‚¶‚é");
        canvas.SetActive(false);
        //SceneManager.LoadScene("testScene");
    }
}
