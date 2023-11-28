using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSample : MonoBehaviour
{
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.gameObject.tag == "Bullets")
        //{
        //    var obj = other.gameObject.GetComponent<EnemyAttack>();
        //    if (obj)
        //    {
        //        Debug.Log(obj.Attack);
        //    }
        //}
    }
}
