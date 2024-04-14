using UnityEngine;
using System.Collections.Generic;

public class Animal : MonoBehaviour
{
    public float speed = 5.0f;  // Velocidade padrão de movimento
    public Transform playerTransform;  // Referência para o transform do jogador

    public float bounceForce = 150.0f;
    
    public string alimento ;
  
    // animais.Add("colobus", "banana");
    // animais.Add("herring", "mato");
    // animais.Add("padu", "queijo");
    // animais.Add("sparrow", "maca");
    // Dictionary<string, string> animais = new Dictionary<string, string>();


    protected virtual void Start()     // Esse virtual serve pra que as classes filhas possam sobrescrever esse método
    {
        


    
        // animais["colobus"] = "banana";
        // animais["herring"] = "mato";
        // animais["padu"] = "mato";
        // animais["sparrow"] = "maca";
        // animais['musckrat'] = "queijo";
        // animais['gecko'] = "mato";
        // animais.Add("colobus", "banana");

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
    // faça um hashmap com os animais e os prefabs deles
 private void OnCollisionEnter(Collision other)
    {
    if (other.gameObject.tag == "Player")
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.AddExplosionForce(bounceForce, transform.position, 1.0f, 0.0f, ForceMode.Impulse);
        }
        if (other.gameObject.CompareTag(alimento)) // Verifica se a colisão foi com o objeto lançado pelo jogador
        {
            // Faça o que precisar quando o animal for atingido pelo objeto do jogador
            Debug.Log("Animal atingido pelo jogador!");
            // Por exemplo, você pode adicionar um efeito, pontuação, ou remover o animal do jogo.
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Player")) // Verifica se a colisão foi com o jogador
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.AddExplosionForce(bounceForce, transform.position, 1.0f, 0.0f, ForceMode.Impulse);
        }

    }




    // private void OnCollisionEnter(Collision other);
   
    
}
