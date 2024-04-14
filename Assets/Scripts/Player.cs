using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
     public GameObject[] projectilePrefab ; // Prefab do objeto que o jogador vai lançar
    public Animator playerAnimator;
    public int selecionado = 0;
     public float projectileSpeed = 20.0f; 
    private Vector3 playerVelocity;
    public float playerSpeed = 2.0f;
    private float yValue;

    private Vector3 look_direction;

    private int numberHiyts = 0;

    private Rigidbody rb;

 void LaunchProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab[selecionado], transform.position + transform.forward, transform.rotation);
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        if (projectileRb != null)
        {
            projectileRb.velocity = transform.forward * projectileSpeed;
        }
    }
    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        yValue = transform.position.y;
        look_direction = Vector3.forward;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    
    

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = move.normalized;
         if (Input.GetKeyDown(KeyCode.Space))
        {
            LaunchProjectile();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            if(selecionado == 5){
                selecionado = 0;
            }else{
                selecionado++;
            }
        
        }
      
       

        if (move != Vector3.zero)
        {
            controller.Move(move * Time.deltaTime * playerSpeed);
            look_direction = move;
            gameObject.transform.forward = move;
            if (!playerAnimator.GetBool("PlayerIsMoving")) playerAnimator.SetBool("PlayerIsMoving", true);
        }
        else{
            if (playerAnimator.GetBool("PlayerIsMoving")) playerAnimator.SetBool("PlayerIsMoving", false);
            // gameObject.transform.LookAt(look_direction);
            gameObject.transform.forward = look_direction;
          
        }
        
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Animal"){
            numberHiyts++;
            Debug.Log("Number of hits: " + numberHiyts);
        }
    }
}