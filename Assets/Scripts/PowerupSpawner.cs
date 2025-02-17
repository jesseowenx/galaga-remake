using System.Collections;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public GameObject[] powerupPrefabs;
    public float spawnIntervalMin = 10f;
    public float spawnIntervalMax = 20f;
    public Vector2 xBounds = new Vector2(-10f, 10f);
    public Vector2 yBounds = new Vector2(-5f, 5f);

    private void Start()
    {
        StartCoroutine(SpawnPowerupRoutine());
    }

    private IEnumerator SpawnPowerupRoutine()
    {
        while (true)
        {
            float spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
            yield return new WaitForSeconds(spawnInterval);

            SpawnPowerup();
        }
    }

    private void SpawnPowerup()
    {
        Vector2 spawnPosition = new Vector2(
            Random.Range(xBounds.x, xBounds.y),
            Random.Range(yBounds.x, yBounds.y)
        );

        int powerupIndex = Random.Range(0, powerupPrefabs.Length);
        Instantiate(powerupPrefabs[powerupIndex], spawnPosition, Quaternion.identity);
    }
}
