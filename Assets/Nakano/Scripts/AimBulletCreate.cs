using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���@�Ɍ������Ĕ��˂����e�𐶐�
/// </summary>
public class AimBulletCreate : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField, Header("AimBullet")] GameObject prefabs;
    [SerializeField, Header("������")] int bulletNum;
    [SerializeField, Header("�N�[���^�C��")] float coolTime;
    [SerializeField, Header("�e��")] float speed;

    AimBullet aimBullet;

    public bool isCreate = false;

    RectTransform rt;
    Vector3 pos;

    void Awake()
    {
        aimBullet = prefabs.GetComponent<AimBullet>();
        aimBullet.speed = speed;

        rt = transform.parent.GetComponent<RectTransform>();
    }

    void Update()
    {
        pos = GetWorldPositionFromRectPosition(rt);

        if (isCreate)
        {
            isCreate = false;
            StartCoroutine(Create());
        }
    }

    IEnumerator Create()
    {
        for (int i = 0; i < bulletNum; i++)
        {
            Instantiate(prefabs, this.transform.localPosition + pos, Quaternion.identity);
            yield return new WaitForSeconds(coolTime);
        }
    }

    private Vector3 GetWorldPositionFromRectPosition(RectTransform rect)
    {
        //UI���W����X�N���[�����W�ɕϊ�
        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, rect.position);

        //���[���h���W
        Vector3 result = Vector3.zero;

        //�X�N���[�����W�����[���h���W�ɕϊ�
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rect, screenPos, canvas.worldCamera, out result);

        return result;
    }
}
