using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class CSVController : MonoBehaviour
{
    [SerializeField, Header("true�̂Ƃ��ʒu�������[�h�ɂȂ�A���W�f�[�^�������o��")] private bool isEdit = false;

    GameObject[] posEdit;

    [SerializeField, Header("���W�������Ă���csv���w��")] private AssetReference csvData;
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
    /// ���W��CSV�t�@�C���ɓ����
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
    /// ���[�h�����t�@�C�����̃e�L�X�g�f�[�^��ʃX�N���v�g�ɗ^����
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
