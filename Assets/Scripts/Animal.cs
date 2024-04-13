using UnityEngine;

public class Animal : MonoBehaviour
{
    public float speed = 5.0f;  // Velocidade padrão de movimento
    private Transform playerTransform;  // Referência para o transform do jogador

    protected virtual void Start()     // Esse virtual serve pra que as classes filhas possam sobrescrever esse método
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Player tag not found on any GameObject.");
            return;
        }
        playerTransform = player.transform;
    }

    void Update()
    {
        if (playerTransform != null)
        {
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
}
