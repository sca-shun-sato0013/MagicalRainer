using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GlobalVariables.HP = 2;
        GlobalVariables.AliveTime = 230f;
    }

    // Update is called once per frame
    void Update()
    {
        
        GlobalVariables.AliveTime += Time.deltaTime;

        Debug.Log(GlobalVariables.AliveTime);
        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene("ResultScene");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
           GlobalVariables.HP += 1;
        }
    }
}
