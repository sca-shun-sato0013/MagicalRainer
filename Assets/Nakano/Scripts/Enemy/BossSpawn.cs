using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    [SerializeField] Vector3[] bossSpawnPos;

    [SerializeField] GameObject[] bulletsObj;

    [SerializeField, Header("ÉVÉÉÉ{Éìã ê∂ê¨à íu")] BubblesPos[] pos;

    [SerializeField] BossController bossController;

    [System.Serializable]
    public class BubblesPos
    {
        public int[] bubblesPos;
    }

    void Start()
    {
    }

    public void BossWarp()
    {
        if(bossController.BossWaveNum == 3)
        {
            int n = Random.Range(0, bossSpawnPos.Length);
            this.transform.localPosition = bossSpawnPos[n];
        }
        
    }

    public void BubblesSpawn()
    {
        if (bossController.BossWaveNum == 3)
        {
            for (int i = 0; i < bulletsObj.Length; i++)
            {
                BubblesPos b = pos[i];
                RandomBubblePos(b.bubblesPos[0], b.bubblesPos[1], b.bubblesPos[2], b.bubblesPos[3], i);
            }
        }
    }

    void RandomBubblePos(int minX, int maxX, int minY, int maxY, int num)
    {
        int x = Random.Range(minX, maxX + 1);
        int y = Random.Range(minY, maxY + 1);
        bulletsObj[num].transform.localPosition = new Vector3(x, y, 0);
    }
}
