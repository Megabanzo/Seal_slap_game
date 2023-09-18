using UnityEngine;

public class BumperController : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public int minSpawnCount = 1;
    public int maxSpawnCount = 5;

    private GameObject[] spawnedObjects;

    public static BumperController I;

    public static int numRounds = 0;
    public int numRoundsToSwap = 3;

    void Start()
    {
        I = this;
    }


    public static void SpawnRandomObs()
    {
        if (numRounds - 1 % I.numRoundsToSwap == 0 && numRounds != 0)
        {
            if (I.spawnedObjects != null) Cleanup();

            // Generate a random number of prefabs to spawn
            int spawnCount = Random.Range(I.minSpawnCount, I.maxSpawnCount + 1);

            // Initialize the array to store spawned objects
            I.spawnedObjects = new GameObject[spawnCount];

            // Spawn the random number of prefabs
            for (int i = 0; i < spawnCount; i++)
            {
                // Calculate a random position within the screen boundaries
                Vector3 spawnPosition = new Vector3(Random.Range(0f, Screen.width), Random.Range(0f, Screen.height), 4f);
                spawnPosition = Camera.main.ScreenToWorldPoint(spawnPosition);

                // Spawn the prefab at the random position and store it in the array
                I.spawnedObjects[i] = Instantiate(I.prefabToSpawn, spawnPosition, Quaternion.identity);
            }
        }
        numRounds++;
    }
    // Add a method to perform cleanup when needed
    public static void Cleanup()
    {
        foreach (GameObject spawnedObject in I.spawnedObjects)
        {
            if (spawnedObject != null)
            {
                Destroy(spawnedObject);
            }
        }
    }
}



