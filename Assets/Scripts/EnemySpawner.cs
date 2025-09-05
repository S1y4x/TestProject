using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemies")]
    [SerializeField] List<GameObject> enemies;

    private Vector2 screenBoundaries;
    private float offset = 2f;

    private void Start()
    {
        float vertExtent = Camera.main.orthographicSize;
        float horExtent = vertExtent * Camera.main.aspect;
        screenBoundaries = new Vector2(horExtent, vertExtent);

        InvokeRepeating("SpawnEnemies", 2, 1);
    }
    void SpawnEnemies()
    {
        if (enemies == null) return;

        int randomNumber = Random.Range(0, enemies.Count);
        Instantiate(enemies[randomNumber], SetLocation(), Quaternion.identity);
    }

    Vector2 SetLocation()
    {
        Vector2 spawnLocation = Vector2.zero;
        int randomPos = Random.Range(0, 4);

        switch(randomPos)
        {
            case 0: spawnLocation = new Vector2(-screenBoundaries.x - offset, Random.Range(-screenBoundaries.y, screenBoundaries.y));
                break;
            case 1: spawnLocation = new Vector2(screenBoundaries.x + offset, Random.Range(-screenBoundaries.y, screenBoundaries.y));
                break;
            case 2: spawnLocation = new Vector2(-screenBoundaries.y - offset, Random.Range(-screenBoundaries.x, -screenBoundaries.x));
                break;
            case 3: spawnLocation = new Vector2(screenBoundaries.y + offset, Random.Range(screenBoundaries.x, -screenBoundaries.x));
                break;
        }
        return spawnLocation;
    }
}
