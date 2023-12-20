using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHpController : MonoBehaviour
{
    [SerializeField] BossController bossController;

    string level;
    string selectChara;

    int damage;

    LevelParam selectCharaParam;
    PlayerParam selectLevelParam;

    [SerializeField] PlayerParams playerParam;

    private void Start()
    {
        if(Difficultylevel.difficulty == null) { level = "Normal"; }
        else level = Difficultylevel.difficulty;

        //charaÇéÊìæ
        selectChara = "CharaA";

        foreach (var c in playerParam.character)
        {
            if(c.charaName == selectChara) { selectCharaParam = c; }
        }

        switch (level)
        {
            case "Easy":
                selectLevelParam = selectCharaParam.easy;
                break;
            case "Normal":
                selectLevelParam = selectCharaParam.normal;
                break;
            case "Hard":
                selectLevelParam = selectCharaParam.hard;
                break;
            case "Galaxy":
                selectLevelParam = selectCharaParam.galaxy;
                break;
        }
    }

    int Atk(string attackType)
    {
        int atk = 0;

        switch(attackType)
        {
            case "SingleAttack":
                atk = selectLevelParam.singleAttack;
                break;
            case "LightAttack":
                atk = selectLevelParam.lightAttack;
                break;
            case "HeavyAttack":
                atk = selectLevelParam.heavyAttack;
                break;
        }

        return atk;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!bossController.Invincible) //ñ≥ìGèÛë‘Ç≈Ç»Ç¢Ç∆Ç´
        {
            //ÉvÉåÉCÉÑÅ[ÇÃíeÇ…ìñÇΩÇ¡ÇΩÇÁ
            if (collision.gameObject.CompareTag("SingleAttack"))
            {
                damage = Atk("SingleAttack");
                bossController.BossHp -= damage;
            }

            if (collision.gameObject.CompareTag("LightAttack"))
            {
                damage = Atk("LightAttack");
                bossController.BossHp -= damage;
            }

            if (collision.gameObject.CompareTag("HeavyAttack"))
            {
                damage = Atk("HeavyAttack");
                bossController.BossHp -= damage;
            }
        }
    }
}