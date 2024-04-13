using System.Collections;
using UnityEngine;


public class AnimalSpawner : MonoBehaviour
{
    public GameObject[] ballPrefabs;  // Array para armazenar os prefabs das bolas
    public float spawnRate = 2.0f;  // Taxa de geração das bolas
    private float nextSpawnTime;

    private float contador_animais = 0;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnBall();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnBall()
    {
        if (ballPrefabs.Length == 0)
        {
            Debug.LogError("No ball prefabs assigned in the spawner.");
            return;
        }
        if (contador_animais <= 10)
        {
            int index = Random.Range(0, ballPrefabs.Length);
            //start on the left side
            Vector3 startPosition = new Vector3(-10, 0, 0);
            GameObject ball = Instantiate(ballPrefabs[index], startPosition, Quaternion.identity);
            contador_animais++;   
        }

        // Assume that each ball prefab has an Animal script attached for movement
    }
}
