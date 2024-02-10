using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    public float spawnRate = 1.0f;
    public float spawnHeight = 10.0f;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        InvokeRepeating("SpawnObject", 0.0f, 1.0f / spawnRate);
    }

    void SpawnObject()
    {
        float randomX = Random.Range(mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x, mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x);
        Vector3 spawnPosition = new Vector3(randomX, mainCamera.ViewportToWorldPoint(new Vector3(1, 1, 0)).y + spawnHeight, 0);

        GameObject selectedPrefab = objectPrefabs[Random.Range(0, objectPrefabs.Length)];

        GameObject newObj = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);

        Destroy(newObj, 3.0f);
    }
}
