using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefabGreen; // Green Item Prefab
    public GameObject itemPrefabRed;   // Red Item Prefab
    public float spawnRate = 1.0f; // Number of items spawned per second

    private void Start()
    {
        StartCoroutine(SpawnItems());
    }

    IEnumerator SpawnItems()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f / spawnRate);
            Vector3 spawnPos = new Vector3(Random.Range(-10, 10), Random.Range(-5, 5), 0);
            GameObject item = Instantiate(Random.value < 0.5f ? itemPrefabGreen : itemPrefabRed, spawnPos, Quaternion.identity);
            item.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        }
    }
}
