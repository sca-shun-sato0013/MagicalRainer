using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float spawnInterval = 2.0f; 
    public float spawnRadius = 5.0f; 


     void Update()
    {
        float randomX = Random.Range(-10f,10f);
        float randomY = Random.Range(-10f,10f);

        Vector2 randomPosition = new Vector2(randomX,randomY);

        Instantiate(EnemyPrefab,randomPosition,Quaternion.identity);
    }
}
