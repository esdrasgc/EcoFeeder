using UnityEngine;

public class sparrow : Animal
{
    
    protected override void Start()
    {
        base.Start();
        speed = 3.0f;  // Velocidade específica para Animal1
        alimento = "maca";
    }


    //  private void OnCollisionEnter(Collision other)
    // {
    // if (other.gameObject.tag == "Player")
    //     {
    //         Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
    //         rb.AddExplosionForce(bounceForce, transform.position, 1.0f, 0.0f, ForceMode.Impulse);
    //     }
    //     if (other.gameObject.CompareTag("maca")) // Verifica se a colisão foi com o objeto lançado pelo jogador
    //     {
    //         // Faça o que precisar quando o animal for atingido pelo objeto do jogador
    //         Debug.Log("Animal atingido pelo jogador!");
    //         // Por exemplo, você pode adicionar um efeito, pontuação, ou remover o animal do jogo.
    //         Destroy(gameObject);
    //         Destroy(other.gameObject);
    //     }
    //     else if (other.gameObject.CompareTag("Player")) // Verifica se a colisão foi com o jogador
    //     {
    //         Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
    //         rb.AddExplosionForce(bounceForce, transform.position, 1.0f, 0.0f, ForceMode.Impulse);
    //     }

    // }

    

}