using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム開始演出終了のフラグをAnimatorのEventから取るためのスクリプト
/// </summary>
public class StartDirection : MonoBehaviour
{
    bool isDirectionEnd = false;

    public bool IsDirectionEnd
    {
        get { return isDirectionEnd; }
    }

    public void endEvent()
    {
        isDirectionEnd = true;
    }
}
