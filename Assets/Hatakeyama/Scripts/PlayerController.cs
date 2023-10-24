using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerManager;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Image image;
    private Vector3 pPos;
    [SerializeField] private float speed = 0.0f;
    [SerializeField] private float startSpeed;
    public static bool playStartFlag;
    public static bool damageFlag;
    private float waitDethEffect = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        pPos = gameObject.transform.position;
        playStartFlag = false;
        damageFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (game_stat)
        {
            case GameStat.START:
                {
                    image.color = new Color(1, 0, 0,1);
                    if (pPos.y <= -460.0f + canvas.pixelRect.height / 2)
                    {
                        gameObject.transform.position = pPos;
                        pPos.y += startSpeed * Time.deltaTime;
                    }
                    else
                    {
                        playStartFlag = true;
                    }
                }
                break;

            case GameStat.PLAY:
                {
                    image.color = new Color(1, 1, 1,1);
                    isNewGame = false;
                    PlayerMove();
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        damageFlag = true;
                    }
                }
                break;

            case GameStat.DETH:
                {
                    image.color = new Color(0, 0, 0,1);
                    waitDethEffect -= Time.deltaTime;
                    if (waitDethEffect<=0)
                    {
                        isPlayerBroken = true;
                        Destroy(gameObject);
                    }
                }
                break;

            case GameStat.REPOP:
                {
                    image.color = new Color(1, 0, 0,0.5f);
                    if (pPos.y <= -460.0f + canvas.pixelRect.height/2)
                    {
                        gameObject.transform.position = pPos;
                        pPos.y += startSpeed * Time.deltaTime;
                    }
                    else
                    {
                        playStartFlag = true;
                    }
                }
                break;
        }
    }

    private void PlayerMove()
    {
        gameObject.transform.position = pPos;
        if (Input.GetKey(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            pPos.y += speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            pPos.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            pPos.x -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            pPos.x += speed * Time.deltaTime;
        }
    }

}
