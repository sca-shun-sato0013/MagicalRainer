using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Q�[���J�n���o�I���̃t���O��Animator��Event�����邽�߂̃X�N���v�g
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
