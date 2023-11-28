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
        REPOP
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
        isNewGame = true;
        startPos = new Vector3(canvas.pixelRect.width/2, -600+canvas.pixelRect.height/2, 0);
        game_stat = GameStat.START;
        isPlayerBroken = true;

        Instantiate(Player, startPos, Quaternion.identity, transform);
    }

    // Update is called once per frame
    void Update()
    {

        if (game_stat==GameStat.START)
        {
            game_stat = GameStat.PLAY;
        }
        if (PlayerController.damageFlag)
        {
            game_stat = GameStat.DETH;
        }
    }
}
