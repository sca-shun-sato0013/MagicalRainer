using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Debug.Log("•Â‚¶‚é");
        canvas.SetActive(false);
    }
}
