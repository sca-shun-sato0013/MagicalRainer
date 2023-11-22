using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    [SerializeField] Vector3[] bossSpawnPos;

    [SerializeField] GameObject[] bulletsObj;

    void Start()
    {
    }

    public void BossWarp()
    {
        int n = Random.Range(0, bossSpawnPos.Length);
        this.transform.localPosition = bossSpawnPos[n];
    }

    public void BubblesSpawn()
    {
        RandomBubblePos(-860, -100, 100, 440, 0);
        RandomBubblePos(100, 860, 100, 440, 1);
        RandomBubblePos(-860, -100, -440, -100, 2);
        RandomBubblePos(100, 860, -440, -100, 3);
    }

    void RandomBubblePos(int minX, int maxX, int minY, int maxY, int num)
    {
        int x = Random.Range(minX, maxX + 1);
        int y = Random.Range(minY, maxY + 1);
        bulletsObj[num].transform.localPosition = new Vector3(x, y, 0);
    }
}
