using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    public bool canSpawn = true;

    public GameObject sheepPrefab;
    // Positions where the sheep will be spawned
    public List<Transform> sheepSpawnPositions = new List<Transform>();
    public float timeBetweenSpawns;

    // List of all the sheep alive in the scene
    private List<GameObject> sheepList = new List<GameObject>();

    private void SpawnSheep()
    {
        // Return a position between 0 and the count of the number of avaliable points, namely 0, 1, or 2
        Vector3 randomPosition = sheepSpawnPositions[Random.Range(0, sheepSpawnPositions.Count)].position;
        // Create a new sheep in the above position and add it to the list
        GameObject sheep = Instantiate(sheepPrefab, randomPosition, sheepPrefab.transform.rotation);
        sheepList.Add(sheep);
        sheep.GetComponent<Sheep>().SetSpawner(this);
    }

    //This is a coroutine, so it can pause and resume its execution over multiple frames or seconds
    // In this case, this will spawn a sheep, pause and then spawn another sheep as long as the spawner is allowed to create new sheep
    //(while canSpawn is true)
    private IEnumerator SpawnRoutine()
    {
        while (canSpawn)
        {
            SpawnSheep();
            // Pause the execution of the coroutine the amount of seconds specified in timeBetweenSpawns
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    public void RemoveSheepFromList(GameObject sheep)
    {
        sheepList.Remove(sheep);
    }

    public void DestroyAllSheep()
    {
        // Iterate over every sheep and destroy every entry
        foreach (GameObject sheep in sheepList)
        {
            Destroy(sheep);
        }

        // Clear the list of sheep references
        sheepList.Clear();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());

        // AIXÒ ES PER FER QUE LA PRIMERA OVELLA FUNCIONI...
        sheepList[0].GetComponent<Sheep>().SetSpawner(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
