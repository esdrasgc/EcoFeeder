using UnityEngine;

public class Animal : MonoBehaviour
{
    public float speed = 5.0f;  // Velocidade padrão de movimento
    public Transform playerTransform;  // Referência para o transform do jogador

    public float bounceForce = 150.0f;


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
            transform.LookAt(playerTransform);
            // 
        }
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        // direction.y = 0;
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.AddExplosionForce(bounceForce, transform.position, 1.0f, 0.0f, ForceMode.Impulse);
        }
    }
}
