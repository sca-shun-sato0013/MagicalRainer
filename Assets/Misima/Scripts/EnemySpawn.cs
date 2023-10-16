using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour  
{
    public GameObject enemyPrefab;
    public Transform leftSpawnPoint;//左のスポーン
    public Transform rightSpawnPoint;//右のスポーン
    [SerializeField]
    public float spawnInterval = 2.0f;//敵のスポーン間隔
    [SerializeField]
    public int maxEnemies = 20;//同時に出現する敵の数
    public string enemyTag = "Enemy";

    private int currentEnemies = 0;
    private float timeSinceLastSpawn = 0;

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        // スポーン間隔ごとに敵を生成
        if (timeSinceLastSpawn >= spawnInterval && currentEnemies < maxEnemies)
        {
            leftSpawnPoint.position = new Vector3(leftSpawnPoint.position.x + 10,
                                                  leftSpawnPoint.position.y,
                                                  leftSpawnPoint.position.z);
            //Debug.Log("通った");
            rightSpawnPoint.position = new Vector3(rightSpawnPoint.position.x - 10,
                                                   rightSpawnPoint.position.y, 
                                                   rightSpawnPoint.position.z);

            SpawnEnemy(leftSpawnPoint);
            SpawnEnemy(rightSpawnPoint);
            timeSinceLastSpawn = 0;
        }
    }

    void SpawnEnemy(Transform spawnPoint)
    {
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        currentEnemies++;

        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag(enemyTag);
        foreach(GameObject enemyObject in enemyObjects)
          {
            EnemyBehavior enemyBehavior = enemyObject.GetComponent<EnemyBehavior>();
            if (enemyBehavior != null)
            {
                enemyBehavior.SetSpawner(this);
            }
        }
    }

    public void EnemyDestroyed()
    {
        currentEnemies--;
    }
}
