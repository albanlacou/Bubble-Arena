using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabsToSpawn; // Liste des prefabs à spawner
    public Transform spawnPoint;
    public float minSpawnTime = 2f;
    public float maxSpawnTime = 10f;
    public float moveSpeed = 5f;
    public float objectLifetime = 10f;

    private float nextSpawnTime;

    void Start()
    {
        ScheduleNextSpawn();
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnObject();
            ScheduleNextSpawn();
        }
    }

    void SpawnObject()
    {
        if (prefabsToSpawn.Length == 0) return; // Vérifie qu'il y a des prefabs dans la liste

        // Choisir un prefab aléatoire dans la liste
        GameObject prefabToSpawn = prefabsToSpawn[Random.Range(0, prefabsToSpawn.Length)];
        GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);

        Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 direction = spawnPoint.right;
            rb.velocity = direction * moveSpeed;
        }

        Destroy(spawnedObject, objectLifetime);
    }

    void ScheduleNextSpawn()
    {
        nextSpawnTime = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
    }
}
