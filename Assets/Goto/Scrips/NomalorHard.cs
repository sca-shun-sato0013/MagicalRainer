using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NomalorHard : MonoBehaviour
{
    public string levelName;
    void Start()
    {

 
    }
    
    public void OnClick()
    {
    
        switch (levelName)
        {
            case "Hard":
                SceneManager.LoadScene("Hard");
                Debug.Log("ハードにいく");
                break;
            case "Nomal":
                SceneManager.LoadScene("Nomal");
                Debug.Log("ノーマルにいく");
                break;
        }
    }
}
