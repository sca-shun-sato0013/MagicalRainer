using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 5.0f;//敵の速度
    public float resetPosition = 10.0f;//出ていく位置
    public float stopTime = 2.0f;//停止する時間
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
        rightBound = new Vector3(0, 0, 1);
        Debug.Log(leftBound);
        Debug.Log(rightBound);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            // 敵を左に移動
            //transform.Translate(Vector3.left * speed * Time.deltaTime);
           
            transform.position = Vector2.MoveTowards(transform.position,
                                                     new Vector2(1,transform.position.y),
                                                     0.1f);
        }
        else
        {
            // 停止時間をカウント
            stopTimer += Time.deltaTime;

            if (stopTimer >= stopTime)
            {
                // 停止時間が終わったら再び移動
                isMoving = true;
                stopTimer = 0;
            }
        }

        // 敵が一定位置を越えたら画面上部に戻す
        if (transform.position.y > resetPosition)
        {
            ResetPosition();
        }

        // 敵が画面左端または右端を越えたら反対側に戻す
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
