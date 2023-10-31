using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GlobalVariables.Score = 100;

        GlobalVariables.AliveTime += Time.deltaTime;

        Debug.Log(GlobalVariables.AliveTime);
        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene("ResultScene");
        }
    }
}
