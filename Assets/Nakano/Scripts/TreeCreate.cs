using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Data
{
    public int num;
    public Vector3 pos;
}

public class TreeCreate : MonoBehaviour
{
    [SerializeField] GameObject prefabs;
    [SerializeField, Header("�e�̉摜")] Sprite sprite;
    [SerializeField, Header("�N�[���^�C��")] float coolTime;
    [SerializeField, Header("������"), Tooltip("������������������ ���͂�1�ȏ�")] int way = 1;
    [SerializeField, Header("�������W����")] Vector3 ajustmentPos;

    [SerializeField, Header("����ɂ����鎞�ԁi�b�j")] float rotateTime;

    [SerializeField, Header("���󂵂Ă����Ƃ��̃N�[���^�C��")] float crumbleCoolTime;
    [SerializeField, Header("����Ă����Ƃ��A�������Ă������ǂ���")] bool isFall;
    [SerializeField, Header("����Ȃ��痎�����Ă����ꍇ�̗����X�s�[�h")] float fallSpeed;

    NormalBullet normalBullet;

    List<Data> posList = new();
    List<GameObject> bullets = new();

    public bool isCreate = false;
    bool isRotate = false;
    bool isCrumble = false;

    //�f�[�^�֌W
    [SerializeField, Header("���W�������Ă���csv���w��")] private AssetReference csvData;
    TextAsset text = null;
    bool isInput = false;

    private void Awake()
    {
        normalBullet = prefabs.GetComponent<NormalBullet>();
        normalBullet.speed = 0;

        prefabs.GetComponent<SpriteRenderer>().sprite = sprite;

        if (way < 1) { way = 1; } //�w�肳�ꂽway��1�����̂Ƃ��A1�ɂ���

        AsyncOperationHandle handle = csvData.LoadAssetAsync<TextAsset>();
        handle.Completed += OnCompletedHandler;
    }

    void Update()
    {
        if (isCreate && isInput)
        {
            isCreate = false;
            StartCoroutine(Create());
        }

        if(isRotate)
        {
            transform.Rotate(0, 0, (360f / rotateTime) * Time.deltaTime * -1);

            if(isCrumble)
            {
                isCrumble = false;
                StartCoroutine(Crumble());
            }
        }
    }

    void DataLoad()
    {
        var split = new List<string>();
        var s = text;
        var lineSplit = s.text.Split("\n"); //�s���Ƃɕ���
        for (var i = 0; i < lineSplit.Length; i++)
        {
            var line = lineSplit[i].Split(",");

            int n = 0;
            if(int.TryParse(line[0] , out n))
            {
                Data data = new();

                data.num = int.Parse(line[0]);
                data.pos = new Vector3(float.Parse(line[1]), float.Parse(line[2]), float.Parse(line[3]));
                posList.Add(data);
            }
        }

        posList.Sort((a, b) => a.num - b.num);

        isInput = true;
    }

    private void OnCompletedHandler(AsyncOperationHandle obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            TextAsset loadedCsv = csvData.Asset as TextAsset;
            if (loadedCsv != null)
            {
                text = loadedCsv;
                DataLoad();
            }
        }
        else
        {
            Debug.LogError($"AssetReference {csvData.RuntimeKey} failed to load.");
        }
    }

    IEnumerator Create()
    {
        for (int i = 1; i <= posList[posList.Count - 1].num; i++)
        {
            foreach(var data in posList)
            {
                if(data.num == i)
                {
                    Vector3 pos = data.pos;
                    for(int w = 1; w <= way; w++)
                    {
                        Vector3 dir = new Vector3(1, 1, 0);

                        switch (w)
                        {
                            case 1:
                                dir = new Vector3(1, 1, 0);
                                break;
                            case 2:
                                dir = new Vector3(-1, -1, 0);
                                break;
                            case 3:
                                dir = new Vector3(-1, 1, 0);
                                break;
                            case 4:
                                dir = new Vector3(1, -1, 0);
                                break;
                        }

                        Vector3 position = pos + this.gameObject.transform.position + ajustmentPos;
                        Vector3 position2 = new Vector3(position.x * dir.x , position.y * dir.y, 0);

                        GameObject obj = Instantiate(prefabs, position2, Quaternion.identity, this.transform);
                        obj.GetComponent<NormalBullet>().num = data.num;
                        bullets.Add(obj);
                    }
                }
            }

            yield return new WaitForSeconds(coolTime);
        }

        isRotate = true;
        isCrumble = true;
    }

    IEnumerator Crumble()
    {
        for (int i = posList[posList.Count - 1].num; i > 0; i--)
        {
            foreach (var o in bullets)
            {
                if(o.GetComponent<NormalBullet>().num == i)
                {
                    if(isFall)
                    {
                        float ajustAngle = o.GetComponent<Transform>().rotation.z;
                        o.GetComponent<NormalBullet>().angle = -90 + ajustAngle + this.transform.rotation.z;
                        o.GetComponent<NormalBullet>().speed = fallSpeed;
                        o.gameObject.transform.parent = null;
                    }
                    else
                    {
                        Destroy(o);
                    }
                }
            }

            yield return new WaitForSeconds(crumbleCoolTime);
        }
    }
}
