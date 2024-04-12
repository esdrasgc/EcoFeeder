using UnityEngine;

public class Animal : MonoBehaviour
{
    public float speed = 5.0f;  // Velocidade padrão de movimento

    private Transform playerTransform;  // Referência para o transform do jogador

    protected virtual void Start()
    {
        // Tentativa de encontrar e armazenar a referência do jogador
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    protected virtual void Update()
    {
        if (playerTransform != null)
        {
            MoveTowardsPlayer();
        }
    }

    protected void MoveTowardsPlayer()
    {
        // Calcula a direção para o jogador a cada frame
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
}
