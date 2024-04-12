using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    public GameObject[] ballPrefabs;  // Array para armazenar os prefabs das bolas
    public float spawnRate = 2.0f;  // Taxa de geração das bolas
    private float nextSpawnTime;

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
        // Escolhe um prefab aleatório das bolas
        int index = Random.Range(0, ballPrefabs.Length);
        GameObject ball = Instantiate(ballPrefabs[index], transform.position, Quaternion.identity);

        // Lança a bola em direção ao jogador
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            rb.velocity = direction * 5.0f;  // Ajuste a velocidade conforme necessário
        }
    }
}
