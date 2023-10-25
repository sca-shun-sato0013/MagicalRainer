using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class CSVController : MonoBehaviour
{
    [SerializeField, Header("trueのとき位置調整モードになり、座標データを書き出す")] private bool isEdit = false;

    GameObject[] posEdit;

    [SerializeField, Header("座標が入っているcsvを指定")] private AssetReference csvData;
    TextAsset text = null;

    private void Awake()
    {
        if (isEdit)
        {
            if(File.Exists(Application.dataPath + "/Nakano/PositionData/hikkaki.csv"))
            {
                File.Delete(Application.dataPath + "/Nakano/PositionData/hikkaki.csv");
            }
            
            posEdit = GameObject.FindGameObjectsWithTag("PosEdit");
            foreach (GameObject obj in posEdit)
            {
                PositionEdit pos = obj.GetComponent<PositionEdit>();
                savePosition("/Nakano/PositionData/hikkaki.csv", pos.num, pos.gameObject.transform.position);
            }
        }
        else
        {
            AsyncOperationHandle handle = csvData.LoadAssetAsync<TextAsset>();
            handle.Completed += OnCompletedHandler;
        }
    }

    /// <summary>
    /// 座標をCSVファイルに入れる
    /// </summary>
    /// <param name="path"></param>
    /// <param name="posNum"></param>
    /// <param name="pos"></param>
    public void savePosition(string path, int posNum, Vector3 pos)
    {
        StreamWriter writer;

        string[] s = {posNum.ToString(), (pos.x).ToString(), (pos.y).ToString(), (pos.z).ToString()};
        string s2 = string.Join(",", s);

        string fileName = Application.dataPath + path;
        writer = new StreamWriter(fileName, true);
        writer.WriteLine(s2);
        writer.Flush();
        writer.Close();
    }

    /// <summary>
    /// ロードしたファイル内のテキストデータを別スクリプトに与える
    /// </summary>
    /// <returns></returns>
    public TextAsset loadPositionData()
    {
        return text;
    }

    private void OnCompletedHandler(AsyncOperationHandle obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            TextAsset loadedCsv = csvData.Asset as TextAsset;
            if (loadedCsv != null)
            {
                text = loadedCsv;
            }
        }
        else
        {
            Debug.LogError($"AssetReference {csvData.RuntimeKey} failed to load.");
        }
    }
}
