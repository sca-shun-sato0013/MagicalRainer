using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerManager;
using UnityEngine.UI;
using Spine.Unity;
using Spine;

public class PlayerController : MonoBehaviour
{
    SkeletonAnimation anim=default;

    private Vector3 pPos;
    [SerializeField] private float speed = 0.0f;
    private float halfSpeed;
    public static bool playStartFlag;
    public static bool damageFlag;
    private float waitDethEffect = 1.0f;
    [SerializeField] private float invisibleTime;

    public static Vector3 pos;

    [SerializeField] private Material playerMaterial;
    private float playerAlpha=1.0f;
    // Start is called before the first frame update
    void Start()
    {
        halfSpeed = speed / 2;
        pPos = gameObject.transform.position;
        playStartFlag = false;
        damageFlag = false;

        anim = GetComponent<SkeletonAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        pos =transform.position;
        playerMaterial.SetFloat("_Range", playerAlpha);
        switch (game_stat)
        {
            case GameStat.START:
                {

                }
                break;

            case GameStat.PLAY:
                {
                    isNewGame = false;
                    PlayerMove();
                    if (!damageFlag)
                    {
                        if (Input.GetKeyDown(KeyCode.LeftShift))
                        {
                            UIManager.HP -= 10;
                            StartCoroutine(Invisible());
                        }
                    }
                }
                break;

            case GameStat.DETH:
                {
                    waitDethEffect -= Time.deltaTime;

                    if (waitDethEffect<=0)
                    {
                        Destroy(gameObject);
                    }
                }
                break;
        }
    }

    private void PlayerMove()
    {
        float moveSpeed;
        if (Input.GetKey(KeyCode.LeftShift)) moveSpeed = halfSpeed;
        else moveSpeed = speed;

        gameObject.transform.position = pPos;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            pPos.y += moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            pPos.y -= moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            pPos.x -= moveSpeed * Time.deltaTime;
            anim.AnimationName = "move left";
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            pPos.x += moveSpeed * Time.deltaTime;
            anim.AnimationName = "move right";
        }

        if (!Input.anyKey||(Input.GetKey(KeyCode.A)&&Input.GetKey(KeyCode.D)))
        {
            anim.AnimationName = "nomaol";
        }
    }

    IEnumerator Invisible()
    {
        playerAlpha=0.5f;
        damageFlag=true;
        yield return new WaitForSeconds(invisibleTime);
        playerAlpha=1.0f;
        damageFlag=false;
    }
}
