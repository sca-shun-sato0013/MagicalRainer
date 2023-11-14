using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField,Header("リザルト")] private GameObject result;
    [SerializeField, Header("ゲームオーバー")] private GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalVariables.HP != 0)
        {
            result.gameObject.SetActive(true);
            gameOver.gameObject.SetActive(false);
        }
        else
        {
            result.gameObject.SetActive(false);
            gameOver.gameObject.SetActive(true);
        }
    }
}

//共有
public static class GlobalVariables
{
    public static float AliveTime = 0f; //生存時間
    public static int Score = 0; //スコア
    public static int HP = 0; //HP
}
