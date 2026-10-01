using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class EnemySpawning : MonoBehaviour
{
    public GameObject basicEnemy;
    public GameObject bossEnemy;
    public int enemiesKilled;
    public bool isBossActive = false;
    float timer;
    [SerializeField] float spawnTimeMin = 0.5f;
    [SerializeField] float spawnTimeMax = 3.0f;
    float currentSpawnTime;
    float minSpawnPos = -4.5f;
    float maxSpawnPos = 4.5f;
    Vector2 bossSpawnPos = new Vector2(8.5f, 0f);

    public void BossSpawn()
    {
        Instantiate(bossEnemy, bossSpawnPos, Quaternion.identity);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSpawnTime = Random.Range(spawnTimeMin, spawnTimeMax); // Chooses the initial random time
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= currentSpawnTime)
        {
            timer = 0;
            Vector3 spawnPos = new Vector3(10f, Random.Range(minSpawnPos, maxSpawnPos), 0f); // Chooses random spawn location
            currentSpawnTime = Random.Range(spawnTimeMin, spawnTimeMax); // Chooses new random time
            Instantiate(basicEnemy, spawnPos, Quaternion.identity); // Spawns in enemy
        }

        if (enemiesKilled == 20 && isBossActive == false)
        {
            BossSpawn();
            enemiesKilled = 0;
            isBossActive = true;
        }
    }
}