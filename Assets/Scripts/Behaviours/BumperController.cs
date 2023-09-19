using UnityEngine;
using UnityEngine.UI;


public class BumperController : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public int minSpawnCount = 1;
    public int maxSpawnCount = 5;
    private static int lastindex = -1;
    private static int index = -1;
    private GameObject[] spawnedObjects;

    public Sprite[] bgs;

    public static BumperController I;

    public static int numRounds = 0;
    public int numRoundsToSwap = 3;
    public Image background;

    public Text roundsDis;

    void Start()
    {
        I = this;
        switchbg();
    }

    public static void switchbg()
    {
        Debug.Log("this");
        while (index == lastindex)
        {
            index = Random.Range(0, I.bgs.Length);
            Debug.Log(index);
        }
        lastindex = index;
        I.background.sprite = I.bgs[index];
    }

    public static void SpawnRandomObs()
    {
        numRounds++;
        I.roundsDis.text = numRounds.ToString();

        if (numRounds  % I.numRoundsToSwap == 0 && numRounds != 0)
        {

            if (I.spawnedObjects != null) Cleanup();
            switchbg();

            // Generate a random number of prefabs to spawn
            int spawnCount = Random.Range(I.minSpawnCount, I.maxSpawnCount + 1);

            // Initialize the array to store spawned objects
            I.spawnedObjects = new GameObject[spawnCount];

            // Spawn the random number of prefabs
            for (int i = 0; i < spawnCount; i++)
            {
                // Calculate a random position within the screen boundaries
                Vector3 spawnPosition = new Vector3(Random.Range(300f, Screen.width - 300), Random.Range(300f, Screen.height-300), 4f);
                spawnPosition = Camera.main.ScreenToWorldPoint(spawnPosition);

                // Spawn the prefab at the random position and store it in the array
                I.spawnedObjects[i] = Instantiate(I.prefabToSpawn, spawnPosition, Quaternion.identity);
            }
        }


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



