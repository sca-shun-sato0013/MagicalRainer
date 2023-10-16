using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 5.0f;//“G‚Ì‘¬“x
    public float resetPosition = 10.0f;//o‚Ä‚¢‚­ˆÊ’u
    public float stopTime = 2.0f;//’â~‚·‚éŠÔ
    private Vector3 startPosition;
    private Vector3 leftBound;
    private Vector3 rightBound;
    private bool isMoving = true;
    private float stopTimer =0;
  

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;


        leftBound = new Vector3(0,0,1);
        rightBound = new Vector3(Screen.width,0,1);
        Debug.Log(leftBound);
        Debug.Log(rightBound);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            // “G‚ğ¶‚ÉˆÚ“®
            //transform.Translate(Vector3.left * speed * Time.deltaTime);
           
            transform.position = Vector2.MoveTowards(transform.position,new Vector2(1,transform.position.y),0.1f);
        }
        else
        {
            // ’â~ŠÔ‚ğƒJƒEƒ“ƒg
            stopTimer += Time.deltaTime;

            if (stopTimer >= stopTime)
            {
                // ’â~ŠÔ‚ªI‚í‚Á‚½‚çÄ‚ÑˆÚ“®
                isMoving = true;
                stopTimer = 0;
            }
        }

        // “G‚ªˆê’èˆÊ’u‚ğ‰z‚¦‚½‚ç‰æ–Êã•”‚É–ß‚·
        if (transform.position.y > resetPosition)
        {
            ResetPosition();
        }

        // “G‚ª‰æ–Ê¶’[‚Ü‚½‚Í‰E’[‚ğ‰z‚¦‚½‚ç”½‘Î‘¤‚É–ß‚·
        if (transform.position.x < leftBound.x - resetPosition || transform.position.x > rightBound.x + resetPosition)
        {

            ResetPosition();
            //Debug.Log(transform.position.x);
            //Debug.Log(leftBound.x);
        }
    }

    void ResetPosition()
    {
            transform.position = startPosition;
            isMoving = false;
    }
}
