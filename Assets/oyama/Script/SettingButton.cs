using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingButton : MonoBehaviour
{
    [SerializeField]
    GameObject settingCanvas;

    public void OnClick()
    {
        Debug.Log("sdf");
        settingCanvas.SetActive(true);
    }
}