using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject smallEnemyPrefab;    // Prefab for small enemy
    public GameObject mediumEnemyPrefab;   // Prefab for medium enemy
    public GameObject heavyEnemyPrefab;    // Prefab for heavy enemy

    public float spawnRadius = 12f;        // Radius of the unit circle for spawning
    public float initialSpawnRate = 0.4f;  // Initial time interval between spawns
    public float rampingFactor = 1.05f;    // Factor by which the spawn rate increases

    private float nextSpawnTime;
    private float currentSpawnRate;

    private float gameTime;                // Total elapsed game time

    void Start()
    {
        currentSpawnRate = initialSpawnRate;
        nextSpawnTime = Time.time + 1f / currentSpawnRate;
    }

    void Update()
    {
        gameTime += Time.deltaTime;

        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + 1f / currentSpawnRate;
            currentSpawnRate *= rampingFactor;
        }
    }

    void SpawnEnemy()
    {
        // Generate a random angle
        float angle = Random.Range(0f, Mathf.PI * 2);

        // Calculate the spawn position
        Vector2 spawnPosition = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * spawnRadius;

        // Determine which enemy type to spawn based on the game time
        GameObject enemyToSpawn = DetermineEnemyType();

        // Instantiate the enemy at the spawn position with no rotation
        Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
    }

    GameObject DetermineEnemyType()
    {
        float smallEnemyThreshold = 30f;  // Time until medium enemies start to appear
        float mediumEnemyThreshold = 60f; // Time until heavy enemies start to appear

        if (gameTime < smallEnemyThreshold)
        {
            return smallEnemyPrefab;
        }
        else if (gameTime < mediumEnemyThreshold)
        {
            return (Random.value > 0.5f) ? smallEnemyPrefab : mediumEnemyPrefab;
        }
        else
        {
            float rand = Random.value;
            if (rand < 0.4f)
            {
                return smallEnemyPrefab;
            }
            else if (rand < 0.8f)
            {
                return mediumEnemyPrefab;
            }
            else
            {
                return heavyEnemyPrefab;
            }
        }
    }
}
