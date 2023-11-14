using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField,Header("���U���g")] private GameObject result;
    [SerializeField, Header("�Q�[���I�[�o�[")] private GameObject gameOver;
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

//���L
public static class GlobalVariables
{
    public static float AliveTime = 0f; //��������
    public static int Score = 0; //�X�R�A
    public static int HP = 0; //HP
}
