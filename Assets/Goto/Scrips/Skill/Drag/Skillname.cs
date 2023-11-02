using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skillname : MonoBehaviour
{
    string  skillname;
    [SerializeField] private GameObject TargetSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        GameObject obj = collision.gameObject;
        Image mg = obj.GetComponent<Image>();
        skillname = mg.sprite.name;
        Debug.Log(skillname);

      

    }
}
