using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�e�L�X�g�����X�ɕ\������
public class MoveText : MonoBehaviour
{
    [SerializeField] private GameObject[] totalObjects;

    [SerializeField, Header("�\������")] private float time = 1.0f; 

    float resetTime;
    int count = -1;
    // Start is called before the first frame update
    void Start()
    {
        resetTime = time;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            count += 1;
            totalObjects[count].SetActive(true);
            time = resetTime;
        }

    }
}
