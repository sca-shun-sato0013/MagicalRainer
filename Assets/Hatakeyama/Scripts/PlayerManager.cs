using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static Canvas canvas;
    public enum GameStat
    {
        START = 0,
        PLAY,
        DETH,
        //REPOP
    }
    [SerializeField]private GameObject Player;
    public static GameStat game_stat;
    public static Vector3 startPos;
    public static bool isNewGame;
    public static bool isPlayerBroken;

    // Start is called before the first frame update
    void OnEnable()
    {
        canvas = GetComponent<Canvas>();
        Debug.Log(canvas.transform.position);
        isNewGame = true;
        startPos = new Vector3(0,-550, 0);
        game_stat = GameStat.START;
        isPlayerBroken = true;

        GameObject obj = Instantiate(Player);
        obj.transform.SetParent(gameObject.transform);
//        GameObject obj = Instantiate(Player, /*startPos*/canvas.transform.position, Quaternion.identity, transform);
        RectTransform rect = obj.GetComponent<RectTransform>();
        rect.localScale = new Vector3(7f, 7f, 7f);
        rect.anchoredPosition3D = startPos;
       
    }

    // Update is called once per frame
    void Update()
    {

        if (game_stat==GameStat.START)
        {
            game_stat = GameStat.PLAY;
        }
        if (UIManager.HP<=0)
        {
            game_stat = GameStat.DETH;
        }
    }
}
