using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Hikkaki : MonoBehaviour
{
    [SerializeField] GameObject prefabs;

    [SerializeField, Header("上段　生成数")] int upNum;
    [SerializeField, Header("中段　生成数")] int middleNum;
    [SerializeField, Header("下段　生成数")] int downNum;

    [SerializeField, Header("弾速")] float speed;

    NormalBullet normalBullet;

    public bool isCreate = false;

    GameObject[] posEdit;
    List<Vector3> upPosList = new();
    List<Vector3> middlePosList = new();
    List<Vector3> downPosList = new();

    CSVController csvController = new();

    void Awake()
    {
        normalBullet = prefabs.GetComponent<NormalBullet>();
        normalBullet.speed = speed;
    }

    private void Start()
    {
        //DataLoad();
    }

    void Update()
    {
        if(isCreate)
        {
            isCreate = false;
            StartCoroutine(Create());
        }
    }

    void DataLoad()
    {
        var split = new List<string>();
        var s = csvController.loadPositionData();
        var lineSplit = s.text.Split("\n"); //行ごとに分割
        for(var i = 0; i < lineSplit.Length; i++)
        {
            var line = lineSplit[i].Split(",");

            switch(int.Parse(line[0]))
            {
                case 1:
                    upPosList.Add(new Vector3(float.Parse(line[1]), float.Parse(line[2]), float.Parse(line[3])));
                    break;
                case 2:
                    middlePosList.Add(new Vector3(float.Parse(line[1]), float.Parse(line[2]), float.Parse(line[3])));
                    break;
                case 3:
                    downPosList.Add(new Vector3(float.Parse(line[1]), float.Parse(line[2]), float.Parse(line[3])));
                    break;
                default:
                    break;
            }
        }
    }

    IEnumerator Create()
    {
        for(int i = 0; i < upNum; i++)
        {
            Vector3 pos = upPosList[Random.Range(0, upPosList.Count)];
            GameObject obj = Instantiate(prefabs, pos, Quaternion.identity);
            obj.GetComponent<NormalBullet>().angle = Random.Range(0, 361);
        }

        for (int i = 0; i < middleNum; i++)
        {
            Vector3 pos = middlePosList[Random.Range(0, middlePosList.Count)];
            GameObject obj = Instantiate(prefabs, pos, Quaternion.identity);
            obj.GetComponent<NormalBullet>().angle = Random.Range(0, 361);
        }

        for (int i = 0; i < downNum; i++)
        {
            Vector3 pos = downPosList[Random.Range(0, downPosList.Count)];
            GameObject obj = Instantiate(prefabs, pos, Quaternion.identity);
            obj.GetComponent<NormalBullet>().angle = Random.Range(0, 361);
        }

        yield return new WaitForEndOfFrame();
    }
}
