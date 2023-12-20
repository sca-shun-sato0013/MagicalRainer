using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSample : MonoBehaviour
{
    [SerializeField] float speed;
    MainGameController mainGameController;
    BossController bossController;

    int stageNum;
    string levelString;
    int bossWaveNum;

    [SerializeField] EnemyParams enemyParams;

    Enemy enemy;
    Boss boss;

    void Start()
    {
        mainGameController = GameObject.FindObjectOfType<MainGameController>();
        bossController = GameObject.FindObjectOfType<BossController>();
        stageNum = mainGameController.StageNumber;
        bossWaveNum = bossController.BossWaveNum;

        if (Difficultylevel.difficulty == null) { levelString = "Normal"; }
        else levelString = Difficultylevel.difficulty;

        foreach (var e in enemyParams.stage)
        {
            if(e.stageNum == stageNum)
            {
                switch (levelString)
                {
                    case "Easy":
                        enemy = e.easy;
                        boss = e.boss.easyBoss;
                        break;
                    case "Normal":
                        enemy = e.normal;
                        boss = e.boss.normalBoss;
                        break;
                    case "Hard":
                        enemy = e.hard;
                        boss = e.boss.hardBoss;
                        break;
                    case "Galaxy":
                        enemy = e.galaxy;
                        boss = e.boss.galaxyBoss;
                        break;
                }
            }
        }
    }

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

        bossWaveNum = bossController.BossWaveNum;
    }

    int EnemyAtk(string EnemyID)
    {
        int atk = 0;

        foreach(var v in enemy.enemy)
        {
            if(v.enemyID == EnemyID) { atk = v.atk; }
        }

        return atk;
    }

    int BossAtk(int BossWaveNum)
    {
        int atk = 0;

        switch (BossWaveNum)
        {
            case 1:
                atk = boss.wave1.atk;
                break;
            case 2:
                atk = boss.wave2.atk;
                break;
            case 3:
                atk = boss.wave3.atk;
                break;
            case 4:
                atk = boss.wave4.atk;
                break;
        }

        return atk;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy1" || other.gameObject.tag == "Enemy2")
        {
            Debug.Log(EnemyAtk(other.gameObject.tag));
        }

        if (other.gameObject.tag == "Boss")
        {
            Debug.Log(BossAtk(bossWaveNum));
        }
    }
}
