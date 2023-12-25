using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect_Init : MonoBehaviour
{
    [SerializeField]
    CharaSelectData charaSelect;

    [SerializeField]
    Button button;

    // Start is called before the first frame update
    void Start()
    {
        charaSelect.CharaSelect(button);    
    }
}
