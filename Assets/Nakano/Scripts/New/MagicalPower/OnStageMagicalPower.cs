using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMagicalPower
{

}

public class OnStageMagicalPower : MonoBehaviour
{
    [SerializeField,Header("マジカルパワーの数")]
    int magicalPowerNumber;

    [SerializeField]
    GameObject magicalPowerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnWaveAppearanceMagicalPower()
    {
        for(int i = 0; i < magicalPowerNumber; i++)
        {            
            GameObject obj = Instantiate(magicalPowerPrefab);
            RectTransform rect = obj.GetComponent<RectTransform>();
            rect.anchoredPosition3D = new Vector3(Random.Range(0,Screen.width),Random.Range(0,Screen.height),0f);
        }
    }
}
